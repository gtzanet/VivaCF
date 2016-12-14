using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiViva2.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {

        [BasicAuthenticationAttributes]
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", UsersSecurity.user_id.ToString() };
        }

        // GET api/values/5
        public string Get(int id)
        {
            if (id ==1)
            {


            } 
         


            return "value";
        }

        // POST api/values
        public IEnumerable<string> Post([FromBody]string value)
        {
            return new string[] { "value1", "value2" };
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
