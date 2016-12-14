using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Threading.Tasks;
using viva2_client.Project.Classes;
using viva2_client;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;

namespace viva2_client.Project
{
    public partial class Projects : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (UserDetails.Email.Trim() == "") RegisterAsyncTask(new PageAsyncTask(SetUserDetails)) ;
         

            RegisterAsyncTask(new PageAsyncTask(LoadFilters));
            RegisterAsyncTask(new PageAsyncTask(LoadProjects));           
        }
        public async Task LoadProjects()
        {
            try
            {
                //HttpCookie aCookie = Request.Cookies["token"];
                //string token = "";
                //if(aCookie != null) token = Server.HtmlEncode(aCookie.Value);

                List<VIva2DataAccess.Projects> projects = new List<VIva2DataAccess.Projects>();
                List<VIva2DataAccess.uvw_ProjectDetails> projectsDetails = new List<VIva2DataAccess.uvw_ProjectDetails>();
                projects = await new GetProjects().GetProjectsList();
                //projects = await new GetProjects().GetProjectsList(token);

                projectsDetails = await new GetProjects().GetProjectDetailsList();

                drawProjects(projects, projectsDetails);
            }
            catch (Exception e)
            {
               // throw e;
                Response.Redirect("~\\ErrorPage.aspx");
            }
        }

        public async Task LoadFilters()
        {
            List<VIva2DataAccess.Categories> categories = new List<VIva2DataAccess.Categories>();
            categories = await new GetFilters().GetCategoriesList();

            List<VIva2DataAccess.SubCategories> subcategories = new List<VIva2DataAccess.SubCategories>();
            subcategories = await new GetFilters().GetSubCategoriesList();

            Filter_Generator filters = new Filter_Generator();
            filters._categories = categories;
            filters._subCategories = subcategories;
            
            ShowFilters.Controls.Add(filters.RenderFilters());
        }

        public void drawProjects(List<VIva2DataAccess.Projects> projects, List<VIva2DataAccess.uvw_ProjectDetails> projectsDetails)
        {
            int i = 0;
            foreach (VIva2DataAccess.Projects item in projects)
            {
                i++;
                item.ImagePath = "../Images/image" + i + ".jpg";

                var itemDetails = projectsDetails.Where(x => x.Project_ID == item.Project_ID).SingleOrDefault();

                Project_Generator pr = new Project_Generator(item, itemDetails);

                ShowProject.Controls.Add(pr.RenderProjectPreview());
            }
        }



        public async Task SetUserDetails()
        {
            try
            {

                HttpCookie aCookie = Request.Cookies["token"];
                string token = "";
                if (aCookie != null) token = Server.HtmlEncode(aCookie.Value);


                HttpContent content;
                string jsonString = "";

                var baseAddress = new Uri("http://localhost:60264/");
                using (var handler1 = new HttpClientHandler { UseCookies = false })
                using (var client = new HttpClient(handler1) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, "api/viva2/1");
                    message.Headers.Add("Cookie", "token=" + token);
                    message.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                   // message.Content = new StringContent(JsonConvert.SerializeObject(Encoding.UTF8, "application/json");

                    var result = await client.SendAsync(message);

                    content = result.Content;
                    jsonString = await content.ReadAsStringAsync();

                    result.EnsureSuccessStatusCode();
                }

                //UserDetails = new Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(UserDetails));
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                UserDetails.Email = (string)json_serializer.DeserializeObject(jsonString);


            }
            catch (Exception e)
            {
                // throw e;
                Response.Redirect("~\\ErrorPage.aspx");
            }
        }
    }
}