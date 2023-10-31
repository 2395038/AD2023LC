using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace BubbleTea
{
    /// <summary>
    /// Interaction logic for EmployeeMangment.xaml
    /// </summary>
    public partial class EmployeeMangment : Window
    {
        public EmployeeMangment()
        {
            InitializeComponent();
       
        }

        public static NpgsqlConnection con;

        public static NpgsqlCommand cmd;

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try { 
            establishConnect();

            con.Open();

                string Query = "insert into employees values(default, @emp_lastName, @emp_firstName, @emp_phone, @emp_email, @emp_password, @emp_totalWH, @scheduled_date, @workshifts)";
                cmd = new NpgsqlCommand(Query, con);

                int workhour = int.Parse(workhours.Text);

                cmd.Parameters.AddWithValue("@emp_lastName", lastName.Text);
                cmd.Parameters.AddWithValue("@emp_firstName", firstName.Text);
                cmd.Parameters.AddWithValue("@emp_phone", phone.Text);
                cmd.Parameters.AddWithValue("@emp_email", email.Text);
                cmd.Parameters.AddWithValue("@emp_password", password.Text);
                cmd.Parameters.AddWithValue("@emp_totalWH", workhour);
                cmd.Parameters.AddWithValue("@scheduled_date", scheduledDate.Text);
                cmd.Parameters.AddWithValue("@workshifts", workShifts.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Empolyee Created Successfully");

                con.Close();

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void establishConnect()
        {
            try { 
                con = new NpgsqlConnection(get_ConnectionString());
                MessageBox.Show("Connection Established");
            } catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string get_ConnectionString()
        {
            string host = "Host=localhost;";
            string port = "Port=5432;";
            string dbName = "Database=BubbleTeaProject;";
            string userName = "Username=postgres;";
            string password = "Password=mary790419;";

            string connectionstring = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return connectionstring;
        }

    
    }
}
