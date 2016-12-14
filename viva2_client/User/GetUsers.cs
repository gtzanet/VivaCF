using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace viva2_client.User.Classes
{
    public class GetUsers
    {
        string _token;
        public GetUsers(string token)
        {
            _token = token;
        }
        public async Task<VIva2DataAccess.Users> GetUser()
        {
            /*
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60264/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resp2 = await client.GetAsync("api/userprofile");
            resp2.EnsureSuccessStatusCode();
            HttpContent content = resp2.Content;
            */

            //HttpCookie aCookie = Request.Cookies["token"];
            //string token = "";
            //if (aCookie != null) token = Server.HtmlEncode(aCookie.Value);

            HttpContent content;
            string jsonString = "";

            var baseAddress = new Uri("http://localhost:60264/");
            using (var handler1 = new HttpClientHandler { UseCookies = false })
            using (var client = new HttpClient(handler1) { BaseAddress = baseAddress })
            {
                var message = new HttpRequestMessage(HttpMethod.Get, "api/userprofile");
                message.Headers.Add("Cookie", "token=" + _token);
                message.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.SendAsync(message);

                content = result.Content;
                jsonString = await content.ReadAsStringAsync();

                result.EnsureSuccessStatusCode();
            }

            VIva2DataAccess.Users user
                = (VIva2DataAccess.Users)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(VIva2DataAccess.Users));

            return user;

        }
    }
}