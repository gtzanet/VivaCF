using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using viva2_client.Project.Classes;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace viva2_client.Project.Classes
{
    public class ProjectBackers_Generator
    {
        VIva2DataAccess.Backers _backers = new VIva2DataAccess.Backers();
        VIva2DataAccess.Projects _project = new VIva2DataAccess.Projects();

        public ProjectBackers_Generator(VIva2DataAccess.Backers backers, VIva2DataAccess.Projects project)
        {
            this._backers = backers;
            this._project = project;
        }

        public Panel RenderProjectBackers()
        {
            // create general div
            Panel generalPanel = new Panel();
            generalPanel.CssClass = "row categories backers";

            Panel leftPanel = new Panel();
            leftPanel.CssClass = "col-md-10";
            leftPanel.Controls.Add(RenderBackerDetails());
            generalPanel.Controls.Add(leftPanel);

            Panel rightPanel = new Panel();
            rightPanel.CssClass = "col-md-2";        
            rightPanel.Controls.Add(RenderBackerDonation());
            generalPanel.Controls.Add(rightPanel);

            return generalPanel;
        }

        public Panel RenderBackerDetails()
        {
            Panel generalPanel = new Panel();
            Label backerName = new Label();
            backerName.Text = _backers.Users.LastName + " " + _backers.Users.FirstName;
            generalPanel.Controls.Add(backerName);

            Label days = new Label();
            days.CssClass = "info";
            DateTime DateCreated = (DateTime)_backers.DateCreated;
            days.Text = (DateTime.Now - DateCreated).Days + " day(s) ago";
            generalPanel.Controls.Add(days);

            return generalPanel;
        }
        public Panel RenderBackerDonation()
        {
            Panel generalPanel = new Panel();
            Label donation = new Label();
            donation.CssClass = "bold";
            donation.Text = _backers.Amount.ToString() + " " + _project.Currencies.Symbol;
            generalPanel.Controls.Add(donation);
            return generalPanel;
        }

    }
}