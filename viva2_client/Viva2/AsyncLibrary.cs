using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace viva2_client.Viva2
{
    public class AsyncLibrary
    {

        public async Task<List<string>> GetUserID()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resp2 = await client.GetAsync("api/viva2/1");

            resp2.EnsureSuccessStatusCode();

            HttpContent content = resp2.Content;
            string jsonString = await content.ReadAsStringAsync();

            //List<VIva2DataAccess.Categories> categories
            //    = (List<VIva2DataAccess.Categories>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(List<VIva2DataAccess.Categories>));

            List<string> res = (List<string>) Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(List<string>));

            return res;

           // return categories;

        }
    }
}