
using Npgsql;
using System;
using System.Buffers.Text;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Diagnostics;
using System.Numerics;

namespace BubbleTea
{
    /// <summary>
    /// EmployeeLogin.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeLogin : Window
    {
        public EmployeeLogin()
        {
            InitializeComponent();
        }

        public static NpgsqlConnection con;

        public static NpgsqlCommand cmd;

        /*public static class EmployeeClass {
           public static string employee_id { get; set; }
            public  static string last_name { get; set; }
            public static string first_name { get; set; }
            public static string email { get; set; }
            public static BigInteger phone { get; set; }
            public static string dept { get; set; }
        }*/
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
        private string Get_ConnectionString()
        {
            string host = "Host=localhost;";
            string port = "Port=5432;";
            string dbName = "Database=VanierFall2023;";
            string userName = "Username=postgres;";
            string password = "Password=123;";

            string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return connectionString;


        }


        public static List<string> EmployeeClass = new List<string>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInfo employeeInfo = new EmployeeInfo();
            try
            {
                establishConnect();

                con.Open();

                string Query = "select * from employee where employee_id = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@id", id.Text);

                bool noData = true;

                NpgsqlDataReader dr = cmd.ExecuteReader();
                dr.Read();





                if (id.Text == dr["employee_id"].ToString() && PIN.Text == dr["password"].ToString())
                {


                    EmployeeClass.Add(dr["employee_id"].ToString());
                    EmployeeClass.Add(dr["last_name"].ToString());
                    EmployeeClass.Add(dr["first_name"].ToString());
                    EmployeeClass.Add(dr["email"].ToString());
                    EmployeeClass.Add(dr["phone"].ToString());
                    EmployeeClass.Add(dr["department"].ToString());
                    MessageBox.Show(EmployeeClass[0]);
                    employeeInfo.Show();

                }
                else
                {
                    MessageBox.Show("ID or Passwrod not correct");
                }
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            employeeInfo.Show();

            this.Close();

        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e, Admin admin)
        {
            Admin admin1 = new Admin();

            try
            {
                establishConnect();

                con.Open();

                string Query = "select * from employee where employee_id = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@id", id.Text);

                bool noData = true;

                NpgsqlDataReader dr = cmd.ExecuteReader();
                dr.Read();





                if (id.Text == dr["employee_id"].ToString() && PIN.Text == dr["password"].ToString())
                {


                    EmployeeClass.Add(dr["employee_id"].ToString());
                    EmployeeClass.Add(dr["last_name"].ToString());
                    EmployeeClass.Add(dr["first_name"].ToString());
                    EmployeeClass.Add(dr["email"].ToString());
                    EmployeeClass.Add(dr["phone"].ToString());
                    EmployeeClass.Add(dr["department"].ToString());
                    MessageBox.Show(EmployeeClass[0]);
                    admin1.Show();
                }
                else
                {
                    MessageBox.Show("ID or Passwrod not correct");
                }
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}