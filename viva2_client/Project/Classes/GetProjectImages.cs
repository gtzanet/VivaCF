using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace viva2_client.Project.Classes
{
    public class GetProjectImages
    {
        public async Task<List<VIva2DataAccess.Images>> GetProjectImagesList(int project_id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resp2 = await client.GetAsync("api/Images/project/" + project_id);
            resp2.EnsureSuccessStatusCode();
            HttpContent content = resp2.Content;
            string jsonString = await content.ReadAsStringAsync();

            List<VIva2DataAccess.Images> Images
                = (List<VIva2DataAccess.Images>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(List<VIva2DataAccess.Images>));

            return Images;
        }
    }
}