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
    public class CategoryController : ApiController
    {
        // GET: Project
        public IEnumerable<Categories> Get()
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                var categories = entities.Categories.ToList();

                foreach (var item in categories)
                {
                    entities.Entry(item).State = EntityState.Detached;
                }

                return categories;

            }
        }

        // GET api/values/5
        public Categories Get(int id)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                return entities.Categories.FirstOrDefault(e => e.Category_ID == id);
            }

        }
    }
}