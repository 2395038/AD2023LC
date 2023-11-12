using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace BubbleTea
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        public Product()
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

                string Query = "insert into product values(@id, @name, @price, @ing, @category)";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));
                cmd.Parameters.AddWithValue("@price",double.Parse(price.Text));
                cmd.Parameters.AddWithValue("@ing", ing.Text);
                cmd.Parameters.AddWithValue("@category", ((ComboBoxItem)category.SelectedItem).Content.ToString());


                cmd.ExecuteNonQuery();

                MessageBox.Show("Product ID Created Successfully");

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

                string Query = "select * from product";

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

                string Query = "select * from product where product_id = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@id", int.Parse(search.Text));

                bool noData = true;

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    noData = false;
                    name.Text = dr["product_name"].ToString();
                    id.Text = dr["product_id"].ToString();
                    price.Text = dr["price"].ToString();
                    ing.Text = dr["ingredients"].ToString();
                    category.Text = dr["category"].ToString();


                }
                if (noData) // checking the data Retrival
                {
                    MessageBox.Show("No such product with that id");
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

                string Query = "UPDATE product SET product_id = @id, product_name=@name, price = @price, ingredients = @ing, category= @category WHERE product_id= @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));
                cmd.Parameters.AddWithValue("@price", double.Parse(price.Text));
                cmd.Parameters.AddWithValue("@ing", ing.Text);
                cmd.Parameters.AddWithValue("@category", ((ComboBoxItem)category.SelectedItem).Content.ToString());

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

                string Query = "DELETE FROM product WHERE product_id = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@id", int.Parse(search.Text));



                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Productwith ID " + int.Parse(id.Text) + " not found.");
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
