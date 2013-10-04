using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;

namespace TrailLocker.DataAccess
{
    public class DAL
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UserTestDb"].ToString());

        public static bool UserIsValid(string username, string password)
        {
            bool authenticated = false;

            string query = string.Format("SELECT * FROM [User] WHERE Username = '{0}' AND Password = '{1}'", username, password);

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            authenticated = sdr.HasRows;
            conn.Close();
            return (authenticated);
        }

        public static void AddUser(string username, string password)
        {
            SqlCommand cmd_insert = new SqlCommand("INSERT INTO User (usernave , password) VALUES (@value1 , @value2, ...)", conn);
            cmd_insert.Parameters.AddWithValue("@value1", username);
            cmd_insert.Parameters.AddWithValue("@value2", password);
            cmd_insert.ExecuteNonQuery();
        }
    }
}
