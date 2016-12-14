using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace viva2_client.Project.Classes
{
    public class GetRewards
    {

        public async Task<List<VIva2DataAccess.Rewards>> GetProjectRewardsList(int project_id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resp2 = await client.GetAsync("api/Reward/project/" + project_id);
            resp2.EnsureSuccessStatusCode();
            HttpContent content = resp2.Content;
            string jsonString = await content.ReadAsStringAsync();

            List<VIva2DataAccess.Rewards> Rewards
                = (List<VIva2DataAccess.Rewards>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(List<VIva2DataAccess.Rewards>));

            return Rewards;
        }

    }
}