using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIva2DataAccess;
using System.Data.Entity;
using System.Web.Http.Cors;

namespace WebApiViva2.Controllers
{
    [RoutePrefix("api/Reward")]
    public class RewardController : ApiController
    {
        // GET: Rewards
       
        [Route("all")]
        public IEnumerable<Rewards> Get()
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                return entities.Rewards
                          .Include(b => b.Projects)
                          .ToList();
            }
        }

        // GET api/Rewards/5
        [Route("project/{id}")]
        public List<Rewards> GetRewardsByProjectID(int id)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                return entities.Rewards
                            .Include(b => b.Projects)
                            .Where(e => e.Project_ID == id)
                            .OrderBy(e => e.MinAmount)
                            .ToList();
            }

        }

        //public class updateProject
        //{
        //    public string title { get; set; }
        //    public string description { get; set; }
        //}


        //public void Put(int id, [FromBody]updateProject projects)
        //{
        //    using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
        //    {
        //        var entity = entities.Projects.FirstOrDefault(x => x.Project_ID == id);
        //        entity.Description = projects.description;
        //        entity.Title = projects.title;

        //        entities.SaveChanges();
        //    }
        //}

    }
}
