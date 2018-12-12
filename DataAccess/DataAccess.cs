using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAppStore.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace MVCAppStore.DataAccess
{
    public class DataAccess
    {

        

        public void InsertUsers(Users UserObj)
        {

            using (var cn = GetSqlConnection())
            {
                string sql = "insert into users(username, firstname,lastname,email, password) values(@username, @firstname,@lastname,@email, @password)";
                var inscmd = new SqlCommand(sql, cn);
                inscmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar)).Value = UserObj.Username;
                inscmd.Parameters.Add(new SqlParameter("@firstname", SqlDbType.NVarChar)).Value = UserObj.Firstname;
                inscmd.Parameters.Add(new SqlParameter("@lastname", SqlDbType.NVarChar)).Value = UserObj.Lastname;
                inscmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar)).Value = UserObj.Email;
                inscmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar)).Value = UserObj.Password;

                cn.Open();
                try
                { 
                   int result = inscmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    cn.Close();
                    inscmd.Dispose();
                }

            }
        }
        public bool IsValid(string Username, string Password)
        {
            bool IsValid = false;

            using (var cn = GetSqlConnection())
            {
                string _sql = @"SELECT [Username] FROM [dbo].[Users] WHERE [Username] = @username AND [Password] = @password";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar)).Value = Username;
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar)).Value = Password;

                cn.Open();
                SqlDataReader reader = null;
                try
                {
                    reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {

                        IsValid = true;
                    }
                    else
                    {

                        IsValid = false;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    reader.Dispose();
                    cmd.Dispose();
                }

            }
            return IsValid;
        }

        public static SqlConnection GetSqlConnection()
        {
            string connection = ConfigurationManager.ConnectionStrings["ProductDataBaseConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            return con;
        }

        public DataTable GetProducts(string sql)
        {
            SqlConnection con = GetSqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

    }
}