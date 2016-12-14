using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIva2DataAccess;
using System.Data.Entity;


namespace WebApiViva2.Controllers
{
    [RoutePrefix("api/Backers")]
    public class BackerController : ApiController
    {

        // GET: Backers
        [Route("all")]
        public IEnumerable<Backers> Get()
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                //return entities.Categories.ToList();

                return entities.Backers
                          .Include(a => a.Users)
                          .Include(b => b.Projects)
                          .ToList();

            }
        }

        // GET api/values/5
        [Route("{id}")]
        public Backers GetBackersByUserID(int id)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                return entities.Backers.FirstOrDefault(e => e.User_ID == id);
            }

        }

        [Route("project/{id}")]
        public List<Backers> GetBackersByProjectID(int id)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                return entities.Backers
                    .Include(b => b.Users)
                    .Include(c => c.Projects)
                    .Where(e => e.Project_ID == id)
                    .ToList();
            }

        }
    }
}
