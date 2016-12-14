using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Viva2WebApi
{
    public class UserSecurity
    {
        public static bool Login(string username, string password)
        {

            Connect_to_DB con = new Connect_to_DB();

            con.OpenConection();

            object result = con.SqlExecuteScalar("select 1 from Users where Username = '" + username + "' and Password = '" + password + "'");

            con.CloseConnection();

            if (result != null) {
                if (result.ToString() == "1")
                {
                        return true;
                }
                else
                {
                    return false;
                }
            }


            return false;

        }
    }
}