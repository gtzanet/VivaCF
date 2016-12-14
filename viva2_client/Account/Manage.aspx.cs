using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using viva2_client.Models;
using viva2_client.Account.Classes;
using System.Web.UI;
using viva2_client.Project.Classes;

namespace viva2_client.Account
{

    public partial class Manage :Page
    {

        int user_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!string.IsNullOrEmpty(Request["user_id"]))
            {
                user_id = Int32.Parse(Request["user_id"]);
            }
            */
            RegisterAsyncTask(new PageAsyncTask(LoadUser));
        }

        public async Task LoadUser()
        {
            try
            {
                VIva2DataAccess.Users user = new VIva2DataAccess.Users();
                //VIva2DataAccess.uvw_ProjectDetails projectsDetails = new VIva2DataAccess.uvw_ProjectDetails();

                user = await new GetUsers().GetUser();
                //projectsDetails = await new GetProjects().GetProjectDetails(project_id);

                drawUser(user);
            }
            catch
            {
                Response.Redirect("~\\ErrorPage.aspx");
            }
        }

        public void drawUser(VIva2DataAccess.Users user)
        {

            string image = "../Images/image1.jpg"; // + user_id + ".jpg";

            User_Generator us = new User_Generator(user, image);

            UserDisplay.Controls.Add(us.RenderUser());
        }
    }
}