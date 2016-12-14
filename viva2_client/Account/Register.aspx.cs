using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using viva2_client.Models;
//using WebApiViva2.Models;
//using WebApiViva2.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace viva2_client.Account
{
    public partial class Register : Page
    {
       // AccountController acct = new AccountController();
        //RegisterBindingModel model = new RegisterBindingModel();

        protected void CreateUser_Click(object sender, EventArgs e)
        {

            
           

            //await acct.Register(model);

            /*var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        */

        }

        //public async Task<List<VIva2DataAccess.Users>> GetCategoriesList()
        //{
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:60264/");
        //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //    var resp2 = await client.GetAsync("api/account/");
        //    resp2.EnsureSuccessStatusCode();
        //    HttpContent content = resp2.Content;
        //    var jsonString = acct.Register(model).Result;

        //   // List<VIva2DataAccess.Categories> categories
        //    //    = (List<VIva2DataAccess.Categories>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(List<VIva2DataAccess.Categories>));

        //    return categories;

        //}
    }
}