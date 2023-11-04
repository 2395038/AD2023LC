using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
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
        private void insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();

                con.Open();

                string Query = "insert into employee values(@id,@lname,@fname, @email, @phone,@dept,@password)";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@lname", lname.Text);
                cmd.Parameters.AddWithValue("@fname", fname.Text);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@phone", BigInteger.Parse(phone.Text));
                cmd.Parameters.AddWithValue("@dept", dept.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Employee Created Successfully");

                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void show_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();

                con.Open();

                string Query = "select * from employee";

                cmd = new NpgsqlCommand(Query, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGrid.ItemsSource = dt.AsDataView();
                DataContext = da;

                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();

                con.Open();

                string Query = "select * from employee where employee_id = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@id", search.Text);

                bool noData = true;

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    noData = false;
                    lname.Text = dr["Last_Name"].ToString();

                    fname.Text = dr["First_Name"].ToString();
                    id.Text = dr["Employee_ID"].ToString();
                    email.Text = dr["Email"].ToString();
                    phone.Text = dr["Phone"].ToString();
                    dept.Text = dr["Department"].ToString();
                    password.Text = dr["Password"].ToString();

                }
                if (noData) // checking the data Retrival
                {
                    MessageBox.Show("No employee with that id");
                }
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();

                con.Open();

                string Query = "UPDATE employee SET last_name = @lname,first_name=@fname, phone = @phone, department = @dept,password= @password WHERE employee_id= @id";

                cmd = new NpgsqlCommand(Query, con);


                cmd.Parameters.AddWithValue("@lname", lname.Text);
                cmd.Parameters.AddWithValue("@fname", fname.Text);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@phone", BigInteger.Parse(phone.Text));
                cmd.Parameters.AddWithValue("@dept", dept.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("employee Updated Successfully");

                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();

                con.Open();

                string Query = "DELETE FROM employee WHERE Employee_ID = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@id", search.Text);



                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Employee with ID " + id.Text + " not found.");
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
