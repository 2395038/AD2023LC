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


namespace Assignment_1
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        public static NpgsqlConnection con; 

        public static NpgsqlCommand cmd; 
        private void insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
               
                con.Open();
                
                string Query = "insert into products values(@name, @id, @amount, @price, default";
                
                cmd = new NpgsqlCommand(Query, con); 

                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));
                cmd.Parameters.AddWithValue("@amount", double.Parse(amount.Text));
                cmd.Parameters.AddWithValue("@price", double.Parse(price.Text));

                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Product Created Successfully");
                
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
            string password = "Password=;";

            string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return connectionString;


        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                
                con.Open();
                
                string Query = "select * from students";
                
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
                
                string Query = "select * from products where id=@id;";
               
                cmd = new NpgsqlCommand(Query, con);
                
                cmd.Parameters.AddWithValue("@id", int.Parse(search.Text));
                
                bool noData = true;
                
                NpgsqlDataReader dr = cmd.ExecuteReader(); 
                
                while (dr.Read())
                {
                    noData = false;
                    name.Text = dr["product_name"].ToString();
                    id.Text = dr["product_id"].ToString();
                    amount.Text = dr["product_amount"].ToString();
                    price.Text = dr["product_price"].ToString();
                    //date.Text = dr["enter_date"].ToString();
                }
                if (noData) // checking the data Retrival
                {
                    MessageBox.Show("No product with that id");
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

                string Query = "UPDATE products SET name = @name, amount = @amount, price = @price WHERE id = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));
                cmd.Parameters.AddWithValue("@amount", double.Parse(amount.Text));
                cmd.Parameters.AddWithValue("@price", double.Parse(price.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Updated Successfully");

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

                string Query = "DELETE FROM products WHERE id = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Product with ID " + int.Parse(id.Text) + " not found.");
                }

                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        
            }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                establishConnect(); 

                con.Open();

                string Query = "SELECT * FROM products WHERE id = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));

                NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                   
                    string productName = reader["name"].ToString();
                    double productAmount = Convert.ToDouble(reader["amount"]);
                    double productPrice = Convert.ToDouble(reader["price"]);

                    MessageBox.Show("Product Found:" +
                                    "\nName: " + productName +
                                    "\nAmount: " + productAmount +
                                    "\nPrice: " + productPrice);
                }
                else
                {
                    MessageBox.Show("Product with ID " + int.Parse(id.Text) + " not found.");
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
