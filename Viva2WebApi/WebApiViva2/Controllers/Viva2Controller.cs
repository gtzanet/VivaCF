using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using VIva2DataAccess;
using System.Web.Http.Cors;

namespace WebApiViva2.Controllers
{
    [EnableCors(origins: "http://localhost:63590", headers: "*", methods: "*")]
    [BasicAuthenticationAttributes]
    public class Viva2Controller : ApiController
    {
      
        public string Post()
        {
            return "SUCCESS";
        }

        public string Get(int id)
        {
            if (id == 1)
            {
                return  UsersSecurity.user_email;

            }
            else
            {
                return "";
            }

       }

    }
}
