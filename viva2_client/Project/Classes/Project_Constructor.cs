using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using Viva2WebApi.Entities;

namespace WebApplication1
{
    public class Project_Constructor
    {
        //public Panel RenderProject(Project project)
        //{
        //    Panel generalPanel = new Panel();
        //    generalPanel.CssClass = "col-md-3 custom";
        //    generalPanel.ID = project.Project_ID.ToString();
        //    //
        //    Panel category = new Panel();
        //    category.CssClass = "category";

        //    Label categoryLabel = new Label();
        //    categoryLabel.Text = "Animals";
        //    categoryLabel.CssClass = "label label-info";
        //    category.Controls.Add(categoryLabel);
        //    generalPanel.Controls.Add(category);
        //    //
        //    Image img = new Image();
        //    img.CssClass = "photo";
        //    img.ImageUrl = project.ImgPath;
        //    generalPanel.Controls.Add(img);
        //    //
        //    var h4 = new HtmlGenericControl("h4");
        //    h4.InnerHtml = project.Title;
        //    h4.Attributes["class"] = "cropHeader";
        //    generalPanel.Controls.Add(h4);
        //    //
        //    var pDesc = new HtmlGenericControl("p");
        //    pDesc.InnerHtml = project.Description;
        //    pDesc.Attributes["class"] = "cropTxt";
        //    generalPanel.Controls.Add(pDesc);
        //    //
        //    var pAmount = new HtmlGenericControl("p");
        //    Label lAmount = new Label();
        //    lAmount.Text = "Animals";
        //    lAmount.CssClass = "amount";
        //    lAmount.Text = "$" + project.FundingGoal;
        //    pAmount.Controls.Add(lAmount);
        //    Label lAmountCurr = new Label();
        //    lAmountCurr.Text = " USD";
        //    pAmount.Controls.Add(lAmountCurr);
        //    generalPanel.Controls.Add(pAmount);
        //    //
        //    Panel progressBarGeneral = new Panel();
        //    progressBarGeneral.CssClass = "progress custom";

        //    Panel progressBar = new Panel();
        //    progressBar.CssClass = "progress-bar";
        //    progressBar.Attributes["role"] = "progressbar";
        //    progressBar.Attributes["aria-valuenow"] = "130";
        //    progressBar.Attributes["aria-valuemin"] = "0";
        //    progressBar.Attributes["aria-valuemax"] = "100";
        //    progressBar.Style.Add("width", "50%");

        //    progressBarGeneral.Controls.Add(progressBar);
        //    generalPanel.Controls.Add(progressBarGeneral);
        //    //
        //    Panel info = new Panel();
        //    info.CssClass = "info";

        //    var pPercentage = new HtmlGenericControl("p");
        //    pPercentage.InnerHtml = "130%";
        //    pPercentage.Attributes["class"] = "alignleft";

        //    var pDays = new HtmlGenericControl("p");
        //    pDays.InnerHtml = "21 days left";
        //    pDays.Attributes["class"] = "alignright";

        //    info.Controls.Add(pPercentage);
        //    info.Controls.Add(pDays);
        //    generalPanel.Controls.Add(info);
        //    //
        //    Panel clear = new Panel();
        //    clear.Attributes["class"] = "clear";
        //    generalPanel.Controls.Add(clear);

        //    return generalPanel;
        //}
    }
}