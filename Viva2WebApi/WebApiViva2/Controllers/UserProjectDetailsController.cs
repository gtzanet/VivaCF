using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIva2DataAccess;

namespace WebApiViva2.Controllers
{
    public class UserProjectDetailsController : ApiController
    {
        // GET: Project
        public IEnumerable<uvw_ProjectDetails> Get()
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                /*
                // return entities.Projects.ToList();
                var entities.Projects
                            .Where(b => b.user_id == UsersSecurity.user_id)
                            .ToList();
                return entities.uvw_ProjectDetails
                            .Where(b => b.project_id == var.project_id)
                          .ToList();
                var query =
                   from pr in entities.Projects
                   join meta in database.Post_Metas on post.ID equals meta.Post_ID
                   where post.ID == id
                   select new { pr_id = pr.project_id, us_id = UsersSecurity.user_id };
                   */
                return entities.uvw_ProjectDetails.ToList(); ;
            }
        }

        // GET api/values/5
        public uvw_ProjectDetails Get(int id)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                return entities.uvw_ProjectDetails.FirstOrDefault(e => e.Project_ID == id);
            }

        }
    }
}
