using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VIva2DataAccess;
using WebApiViva2.Controllers;

namespace WebApiViva2.Controllers
{
    public class CreateProjectController: ApiController
    {
        public void Post([FromBody]Projects project)//[FromBody]Projects project
        {
            var userId = 2;
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                project.User_ID = userId;
                var entity = entities.Projects.Add(project);
                entities.SaveChanges();
            }
        }
    }
}