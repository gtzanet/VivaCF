using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.Threading;
using System.Web.Http;
using VIva2DataAccess;
using System.Data.Entity;
using System.Web.Http.Cors;


namespace WebApiViva2.Controllers
{
    [EnableCors(origins: "http://localhost:63590", headers: "*", methods: "*")]
    [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {   

        // GET: Project
        public IEnumerable<Projects> Get()
        {

            int test = UsersSecurity.user_id;

            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                //return entities.Projects.ToList();

                //return entities.Projects
                //          .Include(b => b.Categories)
                //          .Include(b => b.SubCategories)
                //          .Include(b => b.Currencies)
                //          .Include(b => b.Countries)
                //          .Include(b => b.Rewards)
                //          .ToList();

                var projects = entities.Projects
                            .Include(b => b.Categories)
                            .Include(b => b.SubCategories)
                            .Include(b => b.Currencies)
                            .Include(b => b.Countries)
                            .Include(b => b.Rewards)
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

        // GET api/values/5
        public Projects Get(int id)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                var project = entities.Projects
                            .Include(b => b.Categories)
                            .Include(b => b.SubCategories)
                            .Include(b => b.Currencies)
                            .Include(b => b.Countries)
                            .Include(b => b.Rewards)
                            .FirstOrDefault(e => e.Project_ID == id);

                project.Categories.Projects.Clear();
                project.SubCategories.Projects.Clear();
                project.Currencies.Projects.Clear();
                project.Countries.Projects.Clear();

                return project;
            }

        }

        public class updateProject
        {
            public string title { get; set; }
            public string description { get; set; }

            public string video { get; set; }
            public string category { get; set; }
            public string subcategory { get; set; }

            public string image { get; set; }
        }


        public void Put(int id, [FromBody]updateProject projects)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                var entity = entities.Projects.FirstOrDefault(x => x.Project_ID == id);
                entity.Description = projects.description;
                entity.Title = projects.title;
                entity.Video = projects.video;
                entity.Category_ID = Int32.Parse(projects.category);
                entity.Subcategory_ID = Int32.Parse(projects.subcategory);

                entities.SaveChanges();

                ProjectImagesController img = new ProjectImagesController();
                ProjectImagesController.updateProjectImg bytes = new ProjectImagesController.updateProjectImg();
                bytes.image = projects.image;

                img.Put(id, bytes);
            }
        }

        [Route("editMode/{id}")]
        [HttpGet]
        public bool SetProjectOnEditMode(int id)
        {
            bool IsOK = false;
            int loggedInUserID = UsersSecurity.user_id;
            int projectUserID;

            if (loggedInUserID == 0)
            {
                IsOK = false;
            }
            else
            {
                using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
                {
                    projectUserID = (int)entities.Projects.Where(x => x.Project_ID == id).Select(v => v.User_ID).SingleOrDefault();
                }
                IsOK = (projectUserID == loggedInUserID) ? true : false;
            }
            return IsOK;
        }

    }
}