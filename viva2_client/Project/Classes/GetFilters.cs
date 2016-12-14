using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace viva2_client.Project.Classes
{
    public class GetFilters
    {

        public async Task<List<VIva2DataAccess.Categories>> GetCategoriesList()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resp2 = await client.GetAsync("api/category/");
            resp2.EnsureSuccessStatusCode();
            HttpContent content = resp2.Content;
            string jsonString = await content.ReadAsStringAsync();

            List<VIva2DataAccess.Categories> categories
                = (List<VIva2DataAccess.Categories>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(List<VIva2DataAccess.Categories>));

            return categories;

        }
        public async Task<List<VIva2DataAccess.SubCategories>> GetSubCategoriesList()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resp2 = await client.GetAsync("api/subcategory/");
            resp2.EnsureSuccessStatusCode();
            HttpContent content = resp2.Content;
            string jsonString = await content.ReadAsStringAsync();

            List<VIva2DataAccess.SubCategories> subCategories
                = (List<VIva2DataAccess.SubCategories>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(List<VIva2DataAccess.SubCategories>));

            return subCategories;

        }
    }
}