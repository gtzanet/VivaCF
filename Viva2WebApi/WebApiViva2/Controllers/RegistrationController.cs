using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiViva2.Controllers
{
    public class RegistrationController : ApiController
    {

        public class registrationAccount
        {
            public string email { get; set; }
            public string password { get; set; }
        }


        [BasicAuthenticationAttributes]
        // GET api/registration
        public IEnumerable<string> Get()
        {
          return new  string[] { "value1", "value2" };
        }

        // GET api/registration/5
        public string Get(string email)
        {
            return email;
        }


        [HttpPost]
        // POST api/registration
        public HttpResponseMessage Post([FromBody]registrationAccount value) {

            

            if (value == null) { return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No data provided");}

            //Checking if the email already exists
            string existingAccount = UsersSecurity.ExistingAccount(value.email);

            if (existingAccount == "TRUE")
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Exists");
            }
            else if (existingAccount == "FALSE")
            {
                string result = UsersSecurity.InsertNewAccount(value.email, value.password);

                if (result == "SUCCESS")
                {
                    return Request.CreateErrorResponse(HttpStatusCode.OK, "Successful");
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong");

            }
            else
            {
                //Error that was thrown during the excecution 
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, existingAccount);
            }
        }

        // PUT api/registration/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
