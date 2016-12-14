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
    public class ProjectDetailsController : ApiController
    {
        // GET: Project
        public IEnumerable<uvw_ProjectDetails> Get()
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                // return entities.Projects.ToList();

                return entities.uvw_ProjectDetails
                          .ToList();

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