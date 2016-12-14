using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIva2DataAccess;
using System.Data.Entity;
using System.Web.Http.Cors;
using System.Text;

namespace WebApiViva2.Controllers
{
    [RoutePrefix("api/Images")]
    public class ProjectImagesController : ApiController
    {
        // GET: Images
        [Route("all")]
        public IEnumerable<Images> Get()
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                return entities.Images
                          .Include(b => b.Projects)
                          .ToList();
            }
        }

        // GET api/Images/5
        [Route("project/{id}")]
        public List<Images> GetRewardsByProjectID(int id)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                return entities.Images
                            .Include(b => b.Projects)
                            .Where(e => e.Project_ID == id)
                            .ToList();
            }

        }

        public class updateProjectImg
        {
            public string image { get; set; }
        }


        public void Put(int id, [FromBody]updateProjectImg images)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                var image = new Images { Data = Encoding.ASCII.GetBytes(images.image), Project_ID = id, ContentType ="dd"};
                entities.Images.Add(image);

                entities.SaveChanges();
            }
        }


    }
}
