using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Threading;
using Viva2WebApi;

namespace Viva2WebApi.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private object actionContext;

        // GET api/values
        //public IEnumerable<string> Get()
       [BasicAuthenticationAttributes]
        public HttpResponseMessage Get(string username2 = "aa",string password = "")
        {

            if (username2 != "aa")
            {
                return Request.CreateResponse(HttpStatusCode.OK, "gg");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "not ok");
            //return "";
            /*   string username = Thread.CurrentPrincipal.Identity.Name;
               List<string> MyStringArrays = new List<string>();

               MyStringArrays.Add(username2);
               MyStringArrays.Add(password);

               return Request.CreateResponse(HttpStatusCode.OK, MyStringArrays);

               */



            //return "GOOD";


            /*Connect_to_DB a = new Connect_to_DB();
            a.OpenConection();

            // string sSQL = "SELECT TOP 1 Email FROM Users";

            // string result;

            // result = a.SqlExecuteScalar(sSQL);

            string sSQL = "SELECT Email FROM Users";

            DataTable dataTable = new DataTable();

            dataTable = a.SqlExecuteDataset(sSQL);


            List<string> MyStringArrays = new List<string>();

            foreach (DataRow row in dataTable.Rows)//or similar
            {
                MyStringArrays.Add(row.ItemArray[0].ToString());
            }

            return MyStringArrays.ToArray();
            */
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
    }
}
