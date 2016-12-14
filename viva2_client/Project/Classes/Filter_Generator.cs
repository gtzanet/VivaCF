using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using VIva2DataAccess;

namespace viva2_client.Project.Classes
{
    public class Filter_Generator
    {
        public List<VIva2DataAccess.Categories> _categories = new List<VIva2DataAccess.Categories>();
        public List<VIva2DataAccess.SubCategories> _subCategories = new List<VIva2DataAccess.SubCategories>();
        public bool _Trending = true;

        public int _SelectedCategoryValue = -1;
        public int _SelectedSubCategoryValue = -1;

        public string _CategoryText = "Category";
        public string _SubCategoryText = "Subcategory";
        public string _TrendingText = "Trending";

        public string _CategoryButtonType = "default";
        public string _SubCategoryButtonType = "primary";
        public string _TrendingButtonType = "success";

        string _buttonText;
        string _buttonType;
        string _renderType;

        public Filter_Generator()
        {

        }

        public Panel RenderFilters()
        {
            Panel generalPanel = new Panel();
            generalPanel.CssClass = "categories";

            Panel rowPanel = new Panel();
            rowPanel.CssClass = "row";

            _renderType = "Category";
            _buttonText = _CategoryText;
            _buttonType = _CategoryButtonType;
            rowPanel.Controls.Add(RenderCategories());

            _renderType = "Subcategory";
            _buttonText = _SubCategoryText;
            _buttonType = _SubCategoryButtonType;
            rowPanel.Controls.Add(RenderSubCategories());

            if (_Trending)
            {
                _renderType = "Trending";
                _buttonText = _TrendingText;
                _buttonType = _TrendingButtonType;
                rowPanel.Controls.Add(RenderTrending());
            }

            generalPanel.Controls.Add(rowPanel);

            return generalPanel;
        }

        public Panel RenderCategories()
        {
            Panel categoriesPanel = new Panel();
            categoriesPanel.CssClass = (_Trending) ? "col-xs-6 col-sm-3 col-md-offset-1" : "col-md-6";

            categoriesPanel.Controls.Add(RenderHiddenLabel());
            categoriesPanel.Controls.Add(RenderButton());

            return categoriesPanel;
        }

        public Panel RenderSubCategories()
        {
            Panel subCategoriesPanel = new Panel();
            subCategoriesPanel.CssClass = (_Trending) ? "col-xs-6 col-sm-3" : "col-md-6";

            subCategoriesPanel.Controls.Add(RenderHiddenLabel());
            subCategoriesPanel.Controls.Add(RenderButton());

            return subCategoriesPanel;
        }

        public Panel RenderTrending()
        {
            Panel tredingPanel = new Panel();
            tredingPanel.CssClass = "col-xs-6 col-sm-3";

            tredingPanel.Controls.Add(RenderHiddenLabel());
            tredingPanel.Controls.Add(RenderButton());

            return tredingPanel;
        }

        public Label RenderHiddenLabel()
        {
            Label hiddenLabel = new Label();
            hiddenLabel.CssClass = "dropdownheader info";
            hiddenLabel.Text = _renderType;

            return hiddenLabel;
        }


        public Panel RenderButton()
        {
            Panel buttonPanel = new Panel();
            buttonPanel.CssClass = "btn-group-lg";
            LinkButton button = new LinkButton();
            button.CssClass = "btn btn-" + _buttonType + " dropdown-toggle";
            button.Attributes["data-toggle"] = "dropdown";
            button.ID = _renderType;

            if (_renderType == "Category")
            {
                button.Attributes[_renderType] = (_SelectedCategoryValue != -1) ? _SelectedCategoryValue.ToString() : "0";
            }
            else if (_renderType == "Subcategory")
            {
                button.Attributes[_renderType] = (_SelectedSubCategoryValue != -1) ? _SelectedSubCategoryValue.ToString() : "0";
            }
            else
            {
                button.Attributes[_renderType] = "0";
            }

            HtmlGenericControl buttonText = new HtmlGenericControl("span");
            buttonText.InnerText = _buttonText + " ";
            button.Controls.Add(buttonText);

            HtmlGenericControl span = new HtmlGenericControl("span");
            span.Attributes["class"] = "caret";
            button.Controls.Add(span);

            buttonPanel.Controls.Add(button);
            buttonPanel.Controls.Add(RenderListItems());

            return buttonPanel;
        }

        public HtmlGenericControl RenderListItems()
        {
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.ID = _renderType;
            ul.Attributes["class"] = "dropdown-menu";
            ul.Attributes["role"] = "menu";

            if (_SelectedCategoryValue == -1 || _SelectedSubCategoryValue == -1)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                HyperLink a = new HyperLink();
                a.Text = "All";
                li.Controls.Add(a);
                ul.Controls.Add(li);
            }

            HtmlGenericControl liDivider = new HtmlGenericControl("li");
            liDivider.Attributes["class"] = "divider";
            ul.Controls.Add(liDivider);

            if (_renderType == "Category")
            {
                foreach (VIva2DataAccess.Categories item in _categories)
                {
                    HtmlGenericControl li_ = new HtmlGenericControl("li");
                    HyperLink a_ = new HyperLink();
                    a_.NavigateUrl = "#";
                    a_.Text = item.Description;
                    li_.Attributes["c"] = item.Category_ID.ToString();
                    li_.Controls.Add(a_);
                    ul.Controls.Add(li_);
                }
            }
            else
            {
                foreach (VIva2DataAccess.SubCategories item in _subCategories)
                {
                    HtmlGenericControl li_ = new HtmlGenericControl("li");
                    HyperLink a_ = new HyperLink();
                    a_.NavigateUrl = "#";
                    a_.Text = item.Description;
                    li_.Attributes["c"] = item.Category_ID.ToString();
                    li_.Attributes["cb"] = item.SubCategory_ID.ToString();
                    li_.Controls.Add(a_);
                    ul.Controls.Add(li_);
                }
            }
            

            return ul;
        }
    }
}