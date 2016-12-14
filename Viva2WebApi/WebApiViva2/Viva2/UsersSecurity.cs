using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using VIva2DataAccess;


namespace WebApiViva2
{
    public class UsersSecurity
    {
        public static int user_id;
        public static string user_email;

        public static bool Login(string email, string password)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                try
                {
                    return entities.Users.Any(user => user.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                                                   && user.Password == password);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        [BasicAuthenticationAttributes]
        public static string ExistingAccount(string email)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                try
                {
                    if (entities.Users.Any(user => user.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
                    {
                        return "TRUE";
                    }
                    else
                    {
                        return "FALSE";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public static string InsertNewAccount(string email, string password)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                try
                {
                    entities.Users.Add(new Users
                    {
                        Email = email,
                        Password = password,
                        FirstName = "",
                        LastName = "",
                        Address = "",
                        Username = "lalal"

                    });

                    entities.SaveChanges();

                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "SUCCESS";
        }


        public static void SetUSerID(string email, string password)
        {
            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                try
                {
                    var result = entities.Users.Where(user => user.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                                                  && user.Password == password)
                                                   .Select(user => new { user.User_ID }).ToList();

                    user_id = result.First().User_ID;
                    user_email = email;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



        public static IEnumerable<object> ReturnCustomerDetails()
        {

            using (DreamFountainDBEntities entities = new DreamFountainDBEntities())
            {
                try
                {
                    return entities.Users
                                 .Where(user => user.User_ID == UsersSecurity.user_id)
                                  .Select(user => new { user.FirstName, user.LastName, user.Email })
                                  .ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}