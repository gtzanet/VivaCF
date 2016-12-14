using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using viva2_client.Project.Classes;

namespace viva2_client.Project.Classes
{
    public class AsyncCalls
    {
        public async Task LoadFilters()
        {
            List<VIva2DataAccess.Categories> categories = new List<VIva2DataAccess.Categories>();
            categories = await new GetFilters().GetCategoriesList();

            List<VIva2DataAccess.SubCategories> subcategories = new List<VIva2DataAccess.SubCategories>();
            subcategories = await new GetFilters().GetSubCategoriesList();

            Filter_Generator filters = new Filter_Generator(categories, subcategories);

            //ShowFilters.Controls.Add(filters.RenderFilters());
        }

        public async Task LoadProjects()
        {
            try
            {
                List<VIva2DataAccess.Projects> projects = new List<VIva2DataAccess.Projects>();
                List<VIva2DataAccess.uvw_ProjectDetails> projectsDetails = new List<VIva2DataAccess.uvw_ProjectDetails>();
                projects = await new GetProjects().GetProjectsList();
                projectsDetails = await new GetProjects().GetProjectDetailsList();

                //drawProjects(projects, projectsDetails);
            }
            catch
            {
                //Response.Redirect("~\\ErrorPage.aspx");
            }
        }
    }
}