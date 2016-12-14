using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace viva2_client.Project.Classes
{
    public class GetProjects
    {
        string _token;
        public GetProjects()
        {
        }
        public GetProjects(string token)
        {
            _token = token;
        }
        public async Task<List<VIva2DataAccess.Projects>> GetProjectsList()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var resp2 = await client.GetAsync("api/project/");
           resp2.EnsureSuccessStatusCode();

            HttpContent content = resp2.Content;

            string jsonString = await content.ReadAsStringAsync();
            List<VIva2DataAccess.Projects> projects
                    = (List<VIva2DataAccess.Projects>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(List<VIva2DataAccess.Projects>));

            return projects;

        }

        public async Task<List<VIva2DataAccess.Projects>> GetUserProjectsList()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var resp2 = await client.GetAsync("api/userprojects");
            resp2.EnsureSuccessStatusCode();

            HttpContent content = resp2.Content;

            string jsonString = await content.ReadAsStringAsync();
            List<VIva2DataAccess.Projects> projects
                    = (List<VIva2DataAccess.Projects>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(List<VIva2DataAccess.Projects>));

            return projects;

        }

        public async Task<VIva2DataAccess.Projects> GetProject(int project_id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resp2 = await client.GetAsync("api/project/"+ project_id);
            resp2.EnsureSuccessStatusCode();
            HttpContent content = resp2.Content;
            string jsonString = await content.ReadAsStringAsync();

            VIva2DataAccess.Projects project
                = (VIva2DataAccess.Projects)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(VIva2DataAccess.Projects));

            return project;

        }


        public async Task<List<VIva2DataAccess.uvw_ProjectDetails>> GetProjectDetailsList()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resp2 = await client.GetAsync("api/ProjectDetails/");
            resp2.EnsureSuccessStatusCode();
            HttpContent content = resp2.Content;
            string jsonString = await content.ReadAsStringAsync();

            List<VIva2DataAccess.uvw_ProjectDetails> projectsDetails
                = (List<VIva2DataAccess.uvw_ProjectDetails>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(List<VIva2DataAccess.uvw_ProjectDetails>));

            return projectsDetails;

        }

        public async Task<List<VIva2DataAccess.uvw_ProjectDetails>> GetUserProjectDetailsList()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resp2 = await client.GetAsync("api/ProjectDetails/");
            resp2.EnsureSuccessStatusCode();
            HttpContent content = resp2.Content;
            string jsonString = await content.ReadAsStringAsync();

            List<VIva2DataAccess.uvw_ProjectDetails> projectsDetails
                = (List<VIva2DataAccess.uvw_ProjectDetails>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(List<VIva2DataAccess.uvw_ProjectDetails>));

            return projectsDetails;

        }

        public async Task<VIva2DataAccess.uvw_ProjectDetails> GetProjectDetails(int project_id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resp2 = await client.GetAsync("api/ProjectDetails/" + project_id);
            resp2.EnsureSuccessStatusCode();
            HttpContent content = resp2.Content;
            string jsonString = await content.ReadAsStringAsync();

            VIva2DataAccess.uvw_ProjectDetails projectDetails
                = (VIva2DataAccess.uvw_ProjectDetails)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(VIva2DataAccess.uvw_ProjectDetails));

            return projectDetails;
        }

        public async Task<bool> AllowEditMode(int project_id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resp2 = await client.GetAsync("api/project/editMode/" + project_id);
            resp2.EnsureSuccessStatusCode();
            HttpContent content = resp2.Content;
            string jsonString = await content.ReadAsStringAsync();

            bool editMode = Convert.ToBoolean(jsonString);
            return editMode;

        }
    }
}