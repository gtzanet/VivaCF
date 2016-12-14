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
using viva2_client.User;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using viva2_client.Project.Classes;
using viva2_client.User.Classes;

namespace viva2_client.User
{

    public partial class Profile : Page
    {
        string token = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!string.IsNullOrEmpty(Request["user_id"]))
            {
                user_id = Int32.Parse(Request["user_id"]);
            }
            */
            HttpCookie aCookie = Request.Cookies["token"];
            if (aCookie != null) token = Server.HtmlEncode(aCookie.Value);
            RegisterAsyncTask(new PageAsyncTask(LoadUser));
            RegisterAsyncTask(new PageAsyncTask(LoadProjects));
        }

        public async Task LoadUser()
        {
            try
            {
                VIva2DataAccess.Users user = new VIva2DataAccess.Users();
                //VIva2DataAccess.uvw_ProjectDetails projectsDetails = new VIva2DataAccess.uvw_ProjectDetails();

                user = await new GetUsers(token).GetUser();
                //projectsDetails = await new GetProjects().GetProjectDetails(project_id);

                drawUser(user);
            }
            catch
            {
                Response.Redirect("~\\ErrorPage.aspx");
            }
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
                projects = await new GetProjects(token).GetUserProjectsList();
                //projects = await new GetProjects().GetProjectsList(token);

                projectsDetails = await new GetProjects(token).GetUserProjectDetailsList();

                drawProjects(projects, projectsDetails);
            }
            catch (Exception e)
            {
                // throw e;
                Response.Redirect("~\\ErrorPage.aspx");
            }
        }

        public void drawUser(VIva2DataAccess.Users user)
        {

            string image = "../Images/image1.jpg"; // + user_id + ".jpg";

            User_Generator us = new User_Generator(user, image);

            UserDisplay.Controls.Add(us.RenderUser());
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

                ShowProjects.Controls.Add(pr.RenderProjectPreview());
            }
        }
    }
}