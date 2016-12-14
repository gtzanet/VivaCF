using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using VIva2DataAccess;

namespace WebApiViva2.Controllers
{
    
    public class UserProfileController : ApiController
    {

        // GET api/values
        //public IEnumerable<string> Get()
        //{

        //    return new string[] { "value1", "value2" };
        //}


            [BasicAuthenticationAttributes]
        // GET api/values/5
        public Users GetUserInfo()
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                return entities.Users.FirstOrDefault(e => e.User_ID == UsersSecurity.user_id);
            }
        }

        // POST api/values
        //[BasicAuthenticationAttributes]
        public void Post([FromBody]Users user)
        {            
            var userId = 2;            
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                var entity = entities.Users.FirstOrDefault(x => x.User_ID == userId);
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
                entity.Email = user.Email;
                entities.SaveChanges();
            }
        }

        public void Post(int id, [FromBody]Users user)
        {
            var userId = 2;
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                var entity = entities.Users.FirstOrDefault(x => x.User_ID == userId);
                entity.Password = user.Password;
                entities.SaveChanges();
            }
        }



        // PUT api/userprofile/5
        //[BasicAuthenticationAttributes]
        public void Put(string password)
        {


            var userId = 2;
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                var user = entities.Users.FirstOrDefault(x => x.User_ID == userId);
                user.Password = password;                
                entities.SaveChanges();
            }
        }


        //[BasicAuthenticationAttributes]
        //public void Put(string password)
        //{
        //    using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
        //    {
        //        var entity = entities.Users.FirstOrDefault(x => x.User_ID == 1);
        //        entity.Password = password;
        //        entities.SaveChanges();
        //    }
        //}

        // DELETE api/values/5
        public void Delete(int id)
        {
        }        
    }
}
