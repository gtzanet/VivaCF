using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Threading.Tasks;
using viva2_client.Project.Classes;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Text;

namespace viva2_client.Project
{
    public class paymentValues
    {
        public decimal amount;
        public int pr_id;
    }

    public partial class ProjectDetails : System.Web.UI.Page
    {
        int project_id;
        bool TryForEditMode = false;
        bool editMode = false;

        private const string merchantId = "0054fb51-69ca-4416-8e8a-2fa27b0e171b";
        private const string apiKey = "(QW)1H";


        paymentValues paymentDetails = new paymentValues();

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                var cl = new RestClient("https://demo.vivapayments.com/api/")
                {
                    Authenticator = new HttpBasicAuthenticator(merchantId, apiKey)
                };
                var request = new RestRequest("transactions", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };

                request.AddParameter("PaymentToken", Request.Form["vivaWalletToken"]);

                var response = await cl.ExecuteTaskAsync<TransactionResult>(request);

                if (response.Data != null)
                {
                   // Response.Write(response.Data.ErrorCode + "--" + response.Data.ErrorText);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ////////////////Response.Write("<br />Successful payment");
                        paymentDetails.amount = decimal.Parse(BAmount.Text);
                        paymentDetails.pr_id = Int32.Parse(PrID.Text);

                        RegisterAsyncTask(new PageAsyncTask(InsertPayment));
                    }
                }
                else
                    Response.Write(response.ResponseStatus);
            }



            if (!string.IsNullOrEmpty(Request["project_id"]))
            {
                project_id = Int32.Parse(Request["project_id"]);
            }

            if (!string.IsNullOrEmpty(Request["editMode"]))
            {
                System.Web.HttpCookie aCookie = Request.Cookies["token"];
                TryForEditMode = (aCookie != null) ? true : false;
            }

            RegisterAsyncTask(new PageAsyncTask(LoadProject));
        }

        public async Task InsertPayment()
        {
            try
            {

                //string result = await new Payment().SuccessfulPaymentInserton;
                System.Web.HttpCookie aCookie = Request.Cookies["token"];
                string token = "";
                if (aCookie != null) token = Server.HtmlEncode(aCookie.Value);


                HttpContent content;
                string jsonString = "";

                var baseAddress = new Uri("http://localhost:60264/");
                using (var handler1 = new HttpClientHandler { UseCookies = false })
                using (var client = new HttpClient(handler1) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Post, "api/Payments/");
                    message.Headers.Add("Cookie", "token=" + token);
                    message.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    message.Content = new StringContent(JsonConvert.SerializeObject(paymentDetails), Encoding.UTF8, "application/json");

                    var result = await client.SendAsync(message);

                    content = result.Content;
                    jsonString = await content.ReadAsStringAsync();

                    result.EnsureSuccessStatusCode();
                }



            }
            catch (Exception e)
            {
                // throw e;
                Response.Redirect("~\\ErrorPage.aspx");
            }
        }
   

    public async Task LoadProject()
        {
            try
            {
                VIva2DataAccess.Projects projects = new VIva2DataAccess.Projects();
                VIva2DataAccess.uvw_ProjectDetails projectsDetails = new VIva2DataAccess.uvw_ProjectDetails();
                List<VIva2DataAccess.Backers> projectsBackers = new List<VIva2DataAccess.Backers>();
                List<VIva2DataAccess.Rewards> projectsRewards = new List<VIva2DataAccess.Rewards>();
                List<VIva2DataAccess.Images> projectsImages = new List<VIva2DataAccess.Images>();


                projects = await new GetProjects().GetProject(project_id);
                projectsDetails = await new GetProjects().GetProjectDetails(project_id);
                projectsDetails = await new GetProjects().GetProjectDetails(project_id);

                projectsBackers = await new GetBackers().GetProjectBackersList(project_id);
                projectsRewards = await new GetRewards().GetProjectRewardsList(project_id);
                projectsImages  = await new GetProjectImages().GetProjectImagesList(project_id);

                Filter_Generator filters = new Filter_Generator();
                Panel categorization = new Panel();

                if (TryForEditMode)
                {
                    editMode = await new GetProjects().AllowEditMode(project_id);
                    //editMode = true;
                    if (editMode)
                    {
                        List<VIva2DataAccess.Categories> categories = new List<VIva2DataAccess.Categories>();
                        categories = await new GetFilters().GetCategoriesList();

                        List<VIva2DataAccess.SubCategories> subcategories = new List<VIva2DataAccess.SubCategories>();
                        subcategories = await new GetFilters().GetSubCategoriesList();

                        
                        filters._categories = categories;
                        filters._subCategories = subcategories;
                        filters._Trending = false;

                        filters._CategoryText = projects.Categories.Description;
                        filters._CategoryButtonType = "default";
                        filters._SelectedCategoryValue = projects.Category_ID;

                        filters._SubCategoryText = projects.SubCategories.Description;
                        filters._SubCategoryButtonType = "default";
                        filters._SelectedSubCategoryValue = (int)projects.Subcategory_ID;

                        categorization.Controls.Add(filters.RenderFilters());
                    }
                }

                drawProject(projects, projectsDetails, projectsBackers, projectsRewards, categorization, projectsImages);
            }
            catch
            {
                Response.Redirect("~\\ErrorPage.aspx");
            }
        }

        public void drawProject(VIva2DataAccess.Projects project, VIva2DataAccess.uvw_ProjectDetails projectsDetail
                        , List<VIva2DataAccess.Backers> projectsBacker, List<VIva2DataAccess.Rewards> projectsRewards
                        , Panel categorization, List<VIva2DataAccess.Images> projectsImages)
        {

            project.ImagePath = "../Images/image" + project_id + ".jpg";

            Project_Generator pr = new Project_Generator();
            pr._project = project;
            pr._projectDetails = projectsDetail;
            pr._projectBackers = projectsBacker;
            pr._projectRewards = projectsRewards;
            pr._projectImages = projectsImages;
            pr._categorization = categorization;
            pr.editMode = editMode;

            ShowProject.Controls.Add(pr.RenderProject());
            

        }

    }
}