using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Helpers;
using System.Web.UI;
using VIva2DataAccess;
using WebApiViva2.Controllers;

namespace viva2_client.Account
{
    public partial class ChangePassword : Page
    {
        private UserProfileController userProfileController;

        private Users user;

       // [BasicAuthenticationAttributes]
        protected void Page_Load(object sender, EventArgs e)
        {
            userProfileController = new UserProfileController();            
        }     

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            string jsonString;
            string passwordFromDecodinJson;
            user = new Users();
            user.Password = CurrentPassword.Text;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:60264/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                    
                    var resp2 = client.GetAsync($"api/userprofile?password={user.Password}").Result;
                    HttpContent content2 = resp2.Content;
                    jsonString = content2.ReadAsStringAsync().Result;
                    passwordFromDecodinJson = Json.Decode(jsonString);

                    if (user.Password == passwordFromDecodinJson)
                    {
                        if (NewPassword.Text == RetypePassword.Text)
                        {
                            //smth is wrong here check later
                            user.Password = NewPassword.Text;
                            StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                            var resp3 = client.PostAsync($"api/userprofile/?id=1", content).Result;
                        }

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                
            }
            catch(Exception ex)
            {
                Response.Write("No valid passwords");
            }           
        }
    }
}