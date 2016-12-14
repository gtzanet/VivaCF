using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIva2DataAccess;

namespace WebApiViva2.Controllers
{

    public class paymentValues
    {
        public decimal amount;
        public int pr_id;
    }

   // [BasicAuthenticationAttributes]
    public class PaymentsController : ApiController
    {
        public string Post([FromBody]paymentValues values)
        {
            if (UsersSecurity.user_id == 0 || values == null) return "FAIL";

            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                try
                {
                    entities.Backers.Add(new Backers
                    {
                        User_ID = UsersSecurity.user_id,
                        Project_ID = values.pr_id,
                        Amount = values.amount,
                        DateCreated = DateTime.Now
                    });

                    entities.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return "SUCCESS";
        }
    }
}
