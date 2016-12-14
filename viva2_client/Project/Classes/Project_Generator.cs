using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using VIva2DataAccess;


namespace viva2_client.Project.Classes
{

    public class Project_Generator
    {
        public VIva2DataAccess.Projects _project = new VIva2DataAccess.Projects();
        public VIva2DataAccess.uvw_ProjectDetails _projectDetails = new VIva2DataAccess.uvw_ProjectDetails();
        public List<VIva2DataAccess.Backers> _projectBackers = new List<VIva2DataAccess.Backers>();
        public List<VIva2DataAccess.Rewards> _projectRewards = new List<VIva2DataAccess.Rewards>();
        public List<VIva2DataAccess.Images> _projectImages = new List<VIva2DataAccess.Images>();
        public Panel _categorization;
        public bool editMode = false;

        string headerHight;
        string cropHeaderClass;
        string cropDescrClass;
        string classBackersFund;
        bool TotalFundingVisible;
        string imagesSize;


        public Project_Generator(VIva2DataAccess.Projects project, VIva2DataAccess.uvw_ProjectDetails projectDetails)
        {
            this._project = project;
            this._projectDetails = projectDetails;
        }

        public Project_Generator()
        {
        }


        public void SetAttributes(string mode)
        {
            if (mode == "ProjectPreview")
            {
                headerHight = "h4";
                classBackersFund = "hidden";
                TotalFundingVisible = false;
                cropHeaderClass = "cropHeader";
                cropDescrClass = "cropTxt";
            }
            else if (mode == "Project")
            {
                headerHight = "h2";
                classBackersFund = "";
                TotalFundingVisible = true;
                cropHeaderClass = "";
                cropDescrClass = "";
            }

        }

        public Panel RenderProject()
        {
            SetAttributes("Project");
            // create general div
            Panel generalPanel = new Panel();

            Panel row1 = new Panel();
            row1.CssClass = "row categories";

            Panel leftPanel = new Panel();
            leftPanel.CssClass = "col-md-6 photos";
            leftPanel.Controls.Add(RenderProjectVideoImage());
            row1.Controls.Add(leftPanel);

            Panel rightPanel = new Panel();
            rightPanel.CssClass = "col-md-6";
            rightPanel.Controls.Add(RenderProjectTitle());

            Panel projectDetails = new Panel();
            projectDetails.Controls.Add(RenderProjectFundGoal());
            projectDetails.Controls.Add(RenderProjectProgessBar());
            projectDetails.Controls.Add(RenderProjectProgessInfo());
            if (editMode)
            {
                projectDetails.Controls.Add(RenderVideoURL());
                projectDetails.Controls.Add(_categorization);
                projectDetails.Controls.Add(RenderUpdateButton());
            }
            else
            {
                projectDetails.Controls.Add(RenderFundingButton());
            }
            rightPanel.Controls.Add(projectDetails);

            row1.Controls.Add(rightPanel);

            Panel row2 = new Panel();
            row2.CssClass = "row categories";

            row2.Controls.Add(RenderProjectTabs());

            generalPanel.Controls.Add(row1);
            generalPanel.Controls.Add(row2);

            return generalPanel;

        }

        public Panel RenderProjectPreview()
        {
            SetAttributes("ProjectPreview");
            // create general div
            Panel generalPanel = new Panel();
            generalPanel.CssClass = "col-md-3 custom projects";
            generalPanel.ID = _project.Project_ID.ToString();
            generalPanel.Attributes["c"] = _project.Categories.Category_ID.ToString();
            generalPanel.Attributes["sb"] = _project.SubCategories.SubCategory_ID.ToString();
            generalPanel.Attributes.Add("onclick", "loadProject(" + _project.Project_ID.ToString() + ");");

            // create category div for the category label	
            generalPanel.Controls.Add(RenderProjectCategory());

            // create image and add to general div
            generalPanel.Controls.Add(RenderProjectImage());

            // crete the Project title and add to general div        
            generalPanel.Controls.Add(RenderProjectTitle());

            // create the project description and add to general div
            generalPanel.Controls.Add(RenderProjectDesc());

            // create the line for the funding goal
            generalPanel.Controls.Add(RenderProjectFundGoal());

            // create div for progress bar
            generalPanel.Controls.Add(RenderProjectProgessBar());

            // create div for completion status and remaining days         
            generalPanel.Controls.Add(RenderProjectProgessInfo());

            return generalPanel;
        }

        public Panel RenderProjectTabs()
        {
            Panel bottomPanel = new Panel();
            bottomPanel.CssClass = "col-md-12";

            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Attributes["class"] = "nav nav-tabs";

            /* Overview tab link */
            HtmlGenericControl liOverview = new HtmlGenericControl("li");
            liOverview.Attributes["class"] = "active";
            HyperLink aOverview = new HyperLink();
            aOverview.Text = "Overview";
            aOverview.NavigateUrl = "#MainContent_overview";
            aOverview.Attributes["data-toggle"] = "tab";

            liOverview.Controls.Add(aOverview);
            ul.Controls.Add(liOverview);

            /* Rewards tab link */
            HtmlGenericControl liRewards = new HtmlGenericControl("li");
            HyperLink aRewards = new HyperLink();
            aRewards.Text = "Reward (" + _projectRewards.Count + ")";
            aRewards.NavigateUrl = "#MainContent_rewards";
            aRewards.Attributes["data-toggle"] = "tab";

            liRewards.Controls.Add(aRewards);
            ul.Controls.Add(liRewards);

            /* Backers tab link */
            HtmlGenericControl liBacker = new HtmlGenericControl("li");
            HyperLink aBacker = new HyperLink();
            aBacker.Text = "Backers (" + _projectDetails.Backers + ")";
            aBacker.NavigateUrl = "#MainContent_backers";
            aBacker.Attributes["data-toggle"] = "tab";

            liBacker.Controls.Add(aBacker);
            ul.Controls.Add(liBacker);

            bottomPanel.Controls.Add(ul);

            // ------------------------------------
            Panel tabContent = new Panel();
            tabContent.CssClass = "tab-content clearfix";

            /* tab Overview */
            Panel tabOverview = new Panel();
            tabOverview.CssClass = "tab-pane active fade in custom";
            tabOverview.ID = "overview";
            tabOverview.Attributes["role"] = "tabpanel";
            tabOverview.Controls.Add(RenderProjectDesc());
            tabContent.Controls.Add(tabOverview);

            /* tab Rewards */
            Panel tabRewards = new Panel();
            tabRewards.CssClass = "tab-pane fade custom";
            tabRewards.Attributes["role"] = "tabpanel";
            tabRewards.ID = "rewards";
            tabRewards.Controls.Add(RenderProjectRewards());
            tabContent.Controls.Add(tabRewards);

            /* tab Backers */
            Panel tabBackers = new Panel();
            tabBackers.CssClass = "tab-pane fade custom";
            tabBackers.Attributes["role"] = "tabpanel";
            tabBackers.ID = "backers";
            tabBackers.Controls.Add(RenderProjectBackersDetails());
            tabContent.Controls.Add(tabBackers);

            bottomPanel.Controls.Add(tabContent);

            return bottomPanel;
        }

        public Panel PanelRenderCategorySubCateg()
        {
            Panel generalPanel = new Panel();
            generalPanel.CssClass = "row";

            generalPanel.Controls.Add(RenderProjectCategory());
            generalPanel.Controls.Add(RenderProjectCategory());

            return generalPanel;
        }
        public Panel RenderProjectCategory()
        {
            Panel generalPanel = new Panel();

            if (!editMode)
            {
                generalPanel.CssClass = "category";

                // create the category label
                Label categoryLabel = new Label();
                categoryLabel.Text = _project.Categories.Description;
                categoryLabel.CssClass = "label label-info";
                generalPanel.Controls.Add(categoryLabel);
            }
            else
            {
                generalPanel.CssClass = "col-md-6 input-group input-group-lg";

                TextBox header = new TextBox();
                header.ID = "ProjectVideo";
                header.Text = _project.Video;
                header.CssClass = "form-control";
                HtmlGenericControl icon = new HtmlGenericControl("span");
                icon.Attributes["class"] = "input-group-addon glyphicon glyphicon-pencil";

                generalPanel.Controls.Add(header);
                generalPanel.Controls.Add(icon);

                return generalPanel;

            }
            return generalPanel;
        }

        /* images / video */
        public Panel RenderProjectVideoImage()
        {
            bool videoExists = false;
            bool imgExists = false;

            Panel generalPanel = new Panel();

            if (!String.IsNullOrEmpty(_project.Video))
            {
                videoExists = true;

            }

            if (!String.IsNullOrEmpty(_project.ImagePath))
            {
                imgExists = true;

            }

            Panel bigScreenPanel = new Panel();
            bigScreenPanel.CssClass = "row";

            Panel secScreenPanel = new Panel();
            secScreenPanel.CssClass = "row";

            Panel secScreenPiecesPanel = new Panel();
            secScreenPiecesPanel.CssClass = "col-md-3";

            if (videoExists && imgExists)
            {
                bigScreenPanel.Controls.Add(RenderProjectVideo());
                bigScreenPanel.CssClass = bigScreenPanel.CssClass + " embed-responsive embed-responsive-16by9";
                generalPanel.Controls.Add(bigScreenPanel);

                imagesSize = "small";
                secScreenPiecesPanel.Controls.Add(RenderProjectImage());
                secScreenPanel.Controls.Add(secScreenPiecesPanel);
                generalPanel.Controls.Add(secScreenPanel);
            }
            else if (videoExists && !imgExists)
            {
                bigScreenPanel.Controls.Add(RenderProjectVideo());
                bigScreenPanel.CssClass = bigScreenPanel.CssClass + " embed-responsive embed-responsive-16by9";
                generalPanel.Controls.Add(bigScreenPanel);
            }
            else if (!videoExists && imgExists)
            {
                bigScreenPanel.Controls.Add(RenderProjectImage());
                generalPanel.Controls.Add(bigScreenPanel);
            }
            else
            {
                Label noSources = new Label();
                noSources.Text = "No available Images or Videos";
                bigScreenPanel.Controls.Add(noSources);
                generalPanel.Controls.Add(bigScreenPanel);
            }

            return generalPanel;
        }

        public Image RenderProjectImage()
        {
            Image img = new Image();
            img.CssClass = (imagesSize == "small") ? "img-responsive noMargins" : "img-responsive"; ;
            img.ImageUrl = _project.ImagePath;
            img.Width = (imagesSize == "small") ? 100 : 250;
            img.Height = (imagesSize == "small") ? 100 : 250;

            return img;
        }
        //public Panel RenderProjectImage()
        //{
        //    Panel generalPanel = new Panel();

        //    foreach (VIva2DataAccess.Images item in _projectImages)
        //    {
        //        Byte[] bytes = (Byte[])item.Data;

        //        Image img = new Image();
        //        img.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(bytes);

        //        img.CssClass = (imagesSize == "small") ? "img-responsive noMargins" : "img-responsive"; ;
        //        img.ImageUrl = _project.ImagePath;
        //        img.Width = (imagesSize == "small") ? 100 : 250;
        //        img.Height = (imagesSize == "small") ? 100 : 250;

        //        generalPanel.Controls.Add(img);
        //    }

        //    if (editMode)
        //    {
        //        FileUpload uploadInput = new FileUpload();
        //        uploadInput.ID = "photo-upload";
        //        generalPanel.Controls.Add(uploadInput);

        //        Image uploadedImage = new Image();
        //        uploadedImage.ID = "img";
        //        uploadedImage.Height = (imagesSize == "small") ? 100 : 250;
        //        generalPanel.Controls.Add(uploadedImage);

        //        TextBox path = new TextBox();
        //        path.ID = "b64";
        //        generalPanel.Controls.Add(path);
        //    }
        //    return generalPanel;
        //}

        public HtmlIframe RenderProjectVideo()
        {
            HtmlIframe vid = new HtmlIframe();
            vid.Src = _project.Video;
            vid.Attributes["width"] = "100%";
            vid.Attributes["height"] = "315";
            vid.Attributes["frameborder"] = "0";
            vid.Attributes["allowfullscreen"] = "allowfullscreen";

            return vid;
        }

        public Panel RenderVideoURL()
        {
            Panel generalPanel = new Panel();

            generalPanel.CssClass = "input-group input-group-lg";
            TextBox videoURL = new TextBox();
            videoURL.ID = "ProjectVideo";
            videoURL.Text = _project.Video;
            videoURL.CssClass = "form-control";
            HtmlGenericControl icon = new HtmlGenericControl("span");
            icon.Attributes["class"] = "input-group-addon glyphicon glyphicon-pencil";

            generalPanel.Controls.Add(videoURL);
            generalPanel.Controls.Add(icon);

            return generalPanel;
        }
        /*******/

        public Panel RenderProjectTitle()
        {
            Panel generalPanel = new Panel();

            if (editMode)
            {
                generalPanel.CssClass = "input-group input-group-lg";

                TextBox header = new TextBox();
                header.ID = "ProjectTitle";
                header.Attributes["Placeholder"] = "Title";
                header.Text = _project.Title;
                header.CssClass = "form-control";

                HtmlGenericControl icon = new HtmlGenericControl("span");
                icon.Attributes["class"] = "input-group-addon glyphicon glyphicon-pencil";

                generalPanel.Controls.Add(header);
                generalPanel.Controls.Add(icon);
            }
            else
            {
                HtmlGenericControl header = new HtmlGenericControl(headerHight);
                header.InnerHtml = _project.Title;
                header.Attributes["class"] = cropHeaderClass;
                generalPanel.Controls.Add(header);
            }

            return generalPanel;
        }

        public Panel RenderProjectDesc()
        {
            Panel generalPanel = new Panel();

            if (cropHeaderClass == "")
            {
                HtmlGenericControl header = new HtmlGenericControl("h3");
                header.InnerHtml = "About this project";
                generalPanel.Controls.Add(header);
            }

            if (editMode)
            {
                Panel description = new Panel();
                description.CssClass = "input-group input-group-lg";

                TextBox descriptionTxt = new TextBox();
                descriptionTxt.ID = "ProjectDescription";
                descriptionTxt.Attributes["Placeholder"] = "Description";
                descriptionTxt.Text = _project.Description;
                descriptionTxt.CssClass = "form-control";
                descriptionTxt.TextMode = TextBoxMode.MultiLine;
                descriptionTxt.Rows = 10;

                HtmlGenericControl icon = new HtmlGenericControl("span");
                icon.Attributes["class"] = "input-group-addon glyphicon glyphicon-pencil custom";

                description.Controls.Add(descriptionTxt);
                description.Controls.Add(icon);
                generalPanel.Controls.Add(description);
            }
            else
            {
                HtmlGenericControl pDesc = new HtmlGenericControl("p");
                pDesc.InnerHtml = _project.Description;
                pDesc.Attributes["class"] = cropDescrClass;
                generalPanel.Controls.Add(pDesc);
            }
            return generalPanel;
        }

        public HtmlGenericControl RenderProjectFundGoal()
        {
            var pAmount = new HtmlGenericControl("p");

            Label lAmount = new Label();
            lAmount.CssClass = "amount";
            lAmount.Text = _project.Currencies.Symbol + _projectDetails.AmmountFunded;
            pAmount.Controls.Add(lAmount);

            Label lAmountCurr = new Label();
            lAmountCurr.Text = " " + _project.Currencies.Description;
            pAmount.Controls.Add(lAmountCurr);

            //visible only on project (not in preview)
            Label lBackers = new Label();
            lBackers.Text = " raised by " + _projectDetails.Backers + " backers";
            lBackers.CssClass = classBackersFund;
            pAmount.Controls.Add(lBackers);

            return pAmount;
        }

        public Panel RenderProjectProgessBar()
        {
            Panel progressBarGeneral = new Panel();
            progressBarGeneral.CssClass = "progress custom";

            // create div for progress bar
            Panel progressBar = new Panel();
            progressBar.CssClass = "progress-bar";
            progressBar.Attributes["role"] = "progressbar";
            progressBar.Attributes["aria-valuenow"] = _projectDetails.PercentageFunded;
            progressBar.Attributes["aria-valuemin"] = "0";
            progressBar.Attributes["aria-valuemax"] = "100";
            progressBar.Style.Add("width", _projectDetails.PercentageFunded);
            progressBarGeneral.Controls.Add(progressBar);

            return progressBarGeneral;
        }

        public Panel RenderProjectProgessInfo()
        {
            Panel info = new Panel();
            info.CssClass = "info";

            Panel leftPanel = new Panel();
            leftPanel.CssClass = "col-md-6";
            var pPercentage = new HtmlGenericControl("p");
            pPercentage.InnerHtml = _projectDetails.PercentageFunded;

            if (TotalFundingVisible == true)
            {
                pPercentage.InnerHtml += " of " + _project.Currencies.Symbol + _project.FundingGoal;
            }

            leftPanel.Controls.Add(pPercentage);
            info.Controls.Add(leftPanel);

            Panel rightPanel = new Panel();
            rightPanel.CssClass = "col-md-6";
            var pDays = new HtmlGenericControl("p");
            pDays.InnerHtml = _projectDetails.RemainingTime + " days left";
            pDays.Attributes["class"] = "alignright";
            rightPanel.Controls.Add(pDays);
            info.Controls.Add(rightPanel);

            return info;
        }

        public Panel RenderProjectBackersDetails()
        {
            Panel generalPanel = new Panel();

            HtmlGenericControl header = new HtmlGenericControl("h3");
            header.InnerHtml = "Who supports?";
            generalPanel.Controls.Add(header);

            foreach (VIva2DataAccess.Backers item in _projectBackers)
            {
                ProjectBackers_Generator pr = new ProjectBackers_Generator(item, _project);
                generalPanel.Controls.Add(pr.RenderProjectBackers());
            }

            return generalPanel;

        }

        public Panel RenderProjectRewards()
        {
            Panel generalPanel = new Panel();
            generalPanel.CssClass = "row categories rewards";

            HtmlGenericControl header = new HtmlGenericControl("h3");
            header.InnerHtml = "Rewards";
            generalPanel.Controls.Add(header);

            foreach (VIva2DataAccess.Rewards item in _projectRewards)
            {
                ProjectRewards_Generator pr = new ProjectRewards_Generator();
                pr._rewards = item;
                pr.editMode = editMode;

                generalPanel.Controls.Add(pr.RenderProjectRewards());
            }

            return generalPanel;

        }

        public Panel RenderFundingButton()
        {
            string buttonColor;
            int percentageSymbol = _projectDetails.PercentageFunded.IndexOf("%");

            if (decimal.Parse((_projectDetails.PercentageFunded.Substring(0, percentageSymbol))) >= 100)
            {
                buttonColor = "success";
            }
            else if (decimal.Parse((_projectDetails.PercentageFunded.Substring(0, percentageSymbol))) < 10)
            {
                buttonColor = "danger";
            }
            else
            {
                buttonColor = "info";
            }

            Panel generalPanel = new Panel();
            generalPanel.CssClass = "backerButton row";

            LinkButton button = new LinkButton();
            button.CssClass = "col-md-6 btn btn-lg btn-" + buttonColor + " dropdown-toggle medium";
            button.Text = "BACK IT";
            button.ID = "backButton";
            generalPanel.Controls.Add(button);

            generalPanel.Controls.Add(RenderVivaButton());
            generalPanel.Controls.Add(RenderBackAmount());

            return generalPanel;

        }

        public Panel RenderUpdateButton()
        {
            Panel generalPanel = new Panel();
            generalPanel.CssClass = "backerButton";

            LinkButton button = new LinkButton();
            button.CssClass = "btn btn-lg btn-success dropdown -toggle medium";
            button.Text = "Save Changes";
            button.ID = "saveButton";
            button.OnClientClick = "if(callApiAndSaveProjDetails(" + _project.Project_ID + ")) { return true; } else { return false; }";

            generalPanel.Controls.Add(button);

            Image loadingImg = new Image();
            loadingImg.ImageUrl = "../Images/Loading_icon.gif";
            loadingImg.CssClass = "loadingImg";
            loadingImg.ID = "loadingImg";
            generalPanel.Controls.Add(loadingImg);

            Image savedImg = new Image();
            savedImg.ImageUrl = "../Images/Check.png";
            savedImg.CssClass = "savedImg";
            savedImg.ID = "savedImg";
            generalPanel.Controls.Add(savedImg);

            return generalPanel;

        }

        public Panel RenderBackAmount()
        {
            Panel generalPanel = new Panel();
            generalPanel.ID = "AmountToBack";

            generalPanel.CssClass = "input-group input-group-lg col-md-6";
            TextBox input = new TextBox();
            input.ID = "AmountToBackTXT";
            input.Attributes["Placeholder"] = "Amount";
            input.CssClass = "form-control";
            HtmlGenericControl icon = new HtmlGenericControl("span");
            icon.Attributes["class"] = "input-group-addon glyphicon glyphicon-pencil";

            generalPanel.Controls.Add(input);
            generalPanel.Controls.Add(icon);

            return generalPanel;

        }
        public Panel RenderVivaButton()
        {
            Panel generalPanel = new Panel();
            generalPanel.ID = "vivaButtonDiv";

            Panel button = new Panel();
            button.CssClass = "col-md-6";
            button.ID = "viva_button";
            generalPanel.Controls.Add(button);

            return generalPanel;

        }

    }
}