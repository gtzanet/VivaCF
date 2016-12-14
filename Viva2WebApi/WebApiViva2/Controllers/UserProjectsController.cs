using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIva2DataAccess;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Data.Entity;
using System.Web.Http.Cors;


namespace WebApiViva2.Controllers
{
    [EnableCors(origins: "http://localhost:63590", headers: "*", methods: "*")]
    public class UserProjectsController : ApiController
    {
        public IEnumerable<Projects> Get()
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                //return entities.Projects.ToList();

                var projects = entities.Projects
                          .Include(b => b.Categories)
                          .Include(b => b.SubCategories)
                          .Include(b => b.Currencies)
                          .Include(b => b.Countries)
                          .Include(b => b.Rewards)
                          .Where(b => b.User_ID == UsersSecurity.user_id)
                          .ToList();

                foreach (var item in projects)
                {
                    item.Categories.Projects.Clear();
                    item.SubCategories.Projects.Clear();
                    item.Currencies.Projects.Clear();
                    item.Countries.Projects.Clear();
                }

                return projects;
            }
        }
    }
}
