using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Npgsql;

namespace LogInPage_UnitTest.Models
{
    public class UserAuth
    {
        public static NpgsqlConnection con;

        public static NpgsqlCommand cmd;

        private void establishConnect()
        {
            try
            {
                con = new NpgsqlConnection(get_ConnectionString());
                MessageBox.Show("Connection Established");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private string get_ConnectionString()
        {
            string host = "Host=localhost;";
            string port = "Port=5432;";
            string dbName = "Database=VanierFall2023;";
            string userName = "Username=postgres;";
            string password = "Password=123;";

            string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return connectionString;


        }
        public bool isAuthentication(string employeeId, string password)
        {
            //check user ID exsits and it matches it's password

            try
            {
                establishConnect();

                con.Open();

                string Query = "select * from employee where employee_id = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@id", employeeId);


                NpgsqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (employeeId == dr["employee_id"].ToString() && password == dr["password"].ToString())
                {

                    return true;

                }
                else
                {
                    MessageBox.Show("ID or Passwrod not correct");

                }

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            return false;
           
        }
       
    }
}
