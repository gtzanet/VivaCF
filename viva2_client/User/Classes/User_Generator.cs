using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace viva2_client.Project.Classes
{
    public class User_Generator
    {
        VIva2DataAccess.Users _user = new VIva2DataAccess.Users();
        string _image;

        public User_Generator(VIva2DataAccess.Users user, string image)
        {
            this._user = user;
            _image = image;
        }
        public Panel RenderUser()
        {
            // create general div
            Panel generalPanel = new Panel();
            generalPanel.CssClass = "row categories";

            Panel leftPanel = new Panel();
            leftPanel.CssClass = "col-md-6";
            leftPanel.Controls.Add(RenderUserImage());
            generalPanel.Controls.Add(leftPanel);

            Panel rightPanel = new Panel();
            rightPanel.CssClass = "col-md-6";
            rightPanel.Controls.Add(RenderFirstName());
            rightPanel.Controls.Add(RenderLastName());
            rightPanel.Controls.Add(RenderEmail());
            //rightPanel.Controls.Add(RenderProjectProgessBar());
            //rightPanel.Controls.Add(RenderProjectProgessInfo());
            generalPanel.Controls.Add(rightPanel);

            return generalPanel;

        }

        public Image RenderUserImage()
        {
            Image img = new Image();
            img.CssClass = "photo";
            img.ImageUrl = _image;

            return img;
        }

        public HtmlGenericControl RenderFirstName()
        {
            HtmlGenericControl h4 = new HtmlGenericControl("h4");
            h4.InnerHtml = _user.FirstName;
            h4.Attributes["class"] = "cropHeader";

            return h4;
        }

        public HtmlGenericControl RenderLastName()
        {
            HtmlGenericControl h4 = new HtmlGenericControl("h4");
            h4.InnerHtml = _user.LastName;
            h4.Attributes["class"] = "cropHeader";

            return h4;
        }

        public HtmlGenericControl RenderEmail()
        {
            HtmlGenericControl h4 = new HtmlGenericControl("h4");
            h4.InnerHtml = _user.Email;
            h4.Attributes["class"] = "cropHeader";

            return h4;
        }
    }
}