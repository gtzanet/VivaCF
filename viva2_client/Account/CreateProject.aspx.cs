using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VIva2DataAccess;
using WebApiViva2.Controllers;
//using WebApiViva2.Controllers;

namespace viva2_client.Account
{
    public partial class CreateProject : System.Web.UI.Page
    {
        UserProfileController userProfileController;
        Projects project;
        protected void Page_Load(object sender, EventArgs e)
        {
            userProfileController = new UserProfileController();            

           
        }

        protected void CreateProject_Click(object sender, EventArgs e)
        {
            
            project = new Projects();
            project.Category_ID = Category.SelectedIndex;
            project.Subcategory_ID = SubCategory.SelectedIndex;
            project.Title = ProjectTitle.Text;
            project.Country_ID = Country.SelectedIndex;
            project.FundingGoal = Convert.ToDecimal(FundingGoal.Text);
            project.Video = Video.Text;
            project.ImagePath = Image.Text;
            project.Description = Description.Text;
            project.DateCreated = DateTime.Now;
            project.Currency_ID = Currency.SelectedIndex;
            

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:60264/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    StringContent content = new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8, "application/json");
                    var resp2 = client.PostAsync("api/createproject", content).Result;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error updating " + exception);
            }
            

        }
    }
}