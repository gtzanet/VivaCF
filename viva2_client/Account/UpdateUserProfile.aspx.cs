using System;
using System.Web.UI;
using System.IO;
using Newtonsoft.Json;
using WebApiViva2.Controllers;
using VIva2DataAccess;
using WebApiViva2;
using System.Threading.Tasks;
using viva2_client.Project.Classes;
using System.Net.Http;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace viva2_client.Account
{
    public partial class UpdateUserProfile : Page
    {
        private UserProfileController userProfileController;

        private BasicAuthenticationAttributes basicAuthenticationAttributes;        

        private Users user;




        protected void Page_Load(object sender, EventArgs e)
        {
            userProfileController = new UserProfileController();
            user = new Users();
            //basicAuthenticationAttributes = new BasicAuthenticationAttributes();            
            //StreamReader streamReader = new StreamReader(@"C:\Users\kosta\Source\Repos\CrowdFunding\viva2_client\Account\fakThatJson.json");

            //string json = streamReader.ReadToEnd();
            //users = JsonConvert.DeserializeObject<Users>(json);
            if (!Page.IsPostBack)
            {
                FirstName.Text = user.FirstName;
                LastName.Text = user.LastName;                
                Email.Text = user.Email;
            }
            

        }
        

        protected void UpdateUser_Click(object sender, EventArgs e)
        {       
            user.FirstName = FirstName.Text;
            user.LastName = LastName.Text;
            user.Email = Email.Text;

            try
            {         
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:60264/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    var resp2 = client.PostAsync("api/userprofile", content).Result;              
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error updating " + exception);
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ChangePassword.aspx");
            

        }

        

    }
}