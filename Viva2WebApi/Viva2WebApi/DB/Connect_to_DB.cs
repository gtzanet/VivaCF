using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace Viva2WebApi
{
    public class Connect_to_DB
    {

        //string ConnectionString = @"Server=tcp:vivateam2.database.windows.net,1433;Initial Catalog=DreamFountainDB;Persist Security Info=False;User ID=viva_admin;Password=12345-viv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        string ConnectionString = ConfigurationManager.ConnectionStrings["viva2_db_connection"].ConnectionString;
        SqlConnection con;


        public object Execute_QUERY()
        {
            object result  = new object();



            return result;
        }


        public void OpenConection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
            con.Dispose();
        }


        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public object SqlExecuteScalar(string query)
        {
            try
            {
                SqlCommand SQLCommand = new SqlCommand(query, con);
                SQLCommand.CommandType = CommandType.Text;
                SQLCommand.CommandText = query;

                object aaa = SQLCommand.ExecuteScalar();
                return aaa;

            }
            catch (Exception e)
            {
                string aaaaaa = e.ToString();

                HttpContext.Current.Response.Redirect("~/ErrorRedirect.aspx", false);
                return "";
            }
        }

        public DataTable SqlExecuteDataset(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                SqlCommand SQLCommand = new SqlCommand(query, con);
                SQLCommand.CommandType = CommandType.Text;
                SQLCommand.CommandText = query;

                SqlDataAdapter da = new SqlDataAdapter(SQLCommand);
                da.Fill(dataTable);

                return dataTable;

            }
            catch (Exception)
            {
                HttpContext.Current.Response.Redirect("~/ErrorRedirect.aspx", false);
                return dataTable;
            }
        }
    }
}