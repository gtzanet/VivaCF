using System;
using System.Net.Http;
using System.Threading.Tasks;
using VIva2DataAccess;

namespace viva2_client.Project.Classes
{
    public class GetUsers
    {
        public async Task<Users> GetUser()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resp2 = await client.GetAsync("api/userprofile/1");
            resp2.EnsureSuccessStatusCode();
            HttpContent content = resp2.Content;
            string jsonString = await content.ReadAsStringAsync();

            Users user
                = (Users)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(Users));

            return user;

        }
    }
}