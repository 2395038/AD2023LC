
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


        private void EstablishConnect()
        {
            try
            {
                con = new NpgsqlConnection(Get_ConnectionString());
                MessageBox.Show("Connection Established");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private string Get_ConnectionString()
        {
            string host = "Host=localhost;";
            string port = "Port=5432;";
            string dbName = "Database=ADPorject;";
            string userName = "Username=postgres;";
            string password = "Password=123;";

            string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return connectionString;


        }

        
    private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInfo employeeInfo = new EmployeeInfo();
            try
            {
                EstablishConnect();

                con.Open();

                string Query = "select * from login where employee_id = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));


                NpgsqlDataReader dr = cmd.ExecuteReader();

                if(id.Text == dr["employee_id"].ToString() && PIN.Text == dr["password"].ToString())
                { 
                    
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

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();  
            admin.Show();
        }
    }
}
