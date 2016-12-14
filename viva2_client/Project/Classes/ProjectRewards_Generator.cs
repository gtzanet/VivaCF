using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace viva2_client.Project.Classes
{
    public class ProjectRewards_Generator
    {
        public VIva2DataAccess.Rewards _rewards = new VIva2DataAccess.Rewards();
        public bool editMode = false;

        public ProjectRewards_Generator()
        {

        }

        public Panel RenderProjectRewards()
        {
            // create general div
            Panel generalPanel = new Panel();
            generalPanel.CssClass = "col-md-3 rewards";
            generalPanel.Attributes["minAmount"] = _rewards.MinAmount.ToString(); 

            Panel innerPanel = new Panel();
            innerPanel.CssClass = "row reward";

            innerPanel.Controls.Add(RenderRewardTitle());
            innerPanel.Controls.Add(RenderRewardDesc());

            Panel row1Right = new Panel();
            row1Right.CssClass = "col-md-offset-3 col-md-9 customRewardIcon";
            row1Right.Controls.Add(RenderRewardMinLimit());
            innerPanel.Controls.Add(row1Right);

            generalPanel.Controls.Add(innerPanel);
            return generalPanel;

        }

        public Panel RenderRewardTitle()
        {
            Panel generalPanel = new Panel();

            if (editMode)
            {
                generalPanel.CssClass = "input-group input-group-lg";
                TextBox header = new TextBox();
                header.ID = "RewardTitle";
                header.Text = _rewards.Title;
                header.CssClass = "form-control";
                HtmlGenericControl icon = new HtmlGenericControl("span");
                icon.Attributes["class"] = "input-group-addon glyphicon glyphicon-pencil";

                generalPanel.Controls.Add(header);
                generalPanel.Controls.Add(icon);
            }
            else
            {
                HtmlGenericControl header = new HtmlGenericControl("h4");
                header.InnerHtml = _rewards.Title;
                generalPanel.Controls.Add(header);
            }

            return generalPanel;

        }

        public Panel RenderRewardDesc()
        {
            Panel generalPanel = new Panel();

            if (editMode)
            {
                Panel description = new Panel();
                description.CssClass = "input-group input-group-lg";
                TextBox descriptionTxt = new TextBox();
                descriptionTxt.ID = "ProjectDescription";
                descriptionTxt.Text = _rewards.Description;
                descriptionTxt.CssClass = "form-control";
                descriptionTxt.TextMode = TextBoxMode.MultiLine;
                descriptionTxt.Rows = 3;
                HtmlGenericControl icon = new HtmlGenericControl("span");
                icon.Attributes["class"] = "input-group-addon glyphicon glyphicon-pencil custom";

                description.Controls.Add(descriptionTxt);
                description.Controls.Add(icon);
                generalPanel.Controls.Add(description);
            }
            else
            {
                HtmlGenericControl pDesc = new HtmlGenericControl("p");
                pDesc.InnerHtml = _rewards.Description;
                pDesc.Attributes["class"] = "cropTxt";
                generalPanel.Controls.Add(pDesc);
            }

            return generalPanel;

        }

        public Panel RenderRewardMinLimit()
        {
            Panel generalPanel = new Panel();
            generalPanel.CssClass = "icon";

            Panel innerPannel = new Panel();
            innerPannel.CssClass = "price";

            HtmlGenericControl iconTxtCurrency = new HtmlGenericControl("span");
            iconTxtCurrency.InnerText = "€";
            iconTxtCurrency.Attributes["class"] = "rewardsCurrency";
            innerPannel.Controls.Add(iconTxtCurrency);

            HtmlGenericControl iconTxt = new HtmlGenericControl("span");
            iconTxt.InnerText = Math.Floor((decimal)_rewards.MinAmount).ToString();
            iconTxt.Attributes["class"] = "rewardPrice";
            innerPannel.Controls.Add(iconTxt);

            HtmlGenericControl iconTxtMore = new HtmlGenericControl("span");
            iconTxtMore.InnerText = " or more";
            iconTxtMore.Attributes["class"] = "rewardsMore";
            innerPannel.Controls.Add(iconTxtMore);

            generalPanel.Controls.Add(innerPannel);
            return generalPanel;
        }
    }
}