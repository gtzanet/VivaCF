using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Web.Http;
using VIva2DataAccess;
using System.Data.Entity;


namespace WebApiViva2.Controllers
{
    public class SubCategoryController : ApiController
    {
        // GET: Project
        public IEnumerable<SubCategories> Get()
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {

                //return entities.SubCategories.ToList();


                var subcategories = entities.SubCategories.ToList();

                foreach (var item in subcategories)
                {
                    entities.Entry(item).State = EntityState.Detached;
                }

                return subcategories;

            }
        }

        // GET api/values/5
        public SubCategories Get(int id)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                return entities.SubCategories.FirstOrDefault(e => e.SubCategory_ID == id);
            }

        }
    }
}