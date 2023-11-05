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
using System.Numerics;

namespace BubbleTea
{
    /// <summary>
    /// Interaction logic for Inventroy.xaml
    /// </summary>
    public partial class Inventroy : Window
    {
        public Inventroy()
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

                string Query = "insert into inventroy values(@id,@name, @type, @quantity, @unit)";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));
                cmd.Parameters.AddWithValue("@type", type.Text);
                cmd.Parameters.AddWithValue("@quantity", int.Parse(quantity.Text));
                cmd.Parameters.AddWithValue("@unit", unit.Text);
           

                cmd.ExecuteNonQuery();

                MessageBox.Show("Inventroy ID Created Successfully");

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

                string Query = "select * from inventroy";

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

                string Query = "select * from inventroy where inventroy_id = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@id", int.Parse(search.Text));
                
                bool noData = true;

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    noData = false;
                    name.Text = dr["product_name"].ToString();
                    id.Text = dr["inventroy_id"].ToString();
                    type.Text = dr["material_type"].ToString();
                    quantity.Text = dr["quantity"].ToString();
                    unit.Text = dr["unit_measurement"].ToString();


                }
                if (noData) // checking the data Retrival
                {
                    MessageBox.Show("No such inventroy with that id");
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

                string Query = "UPDATE inventroy SET inventroy_id = @id,product_name=@name, material_type = @type, quantity = @quantity,unit_measurement= @unit WHERE inventroy_id= @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));
                cmd.Parameters.AddWithValue("@type", type.Text);
                cmd.Parameters.AddWithValue("@quantity", int.Parse(quantity.Text));
                cmd.Parameters.AddWithValue("@unit", unit.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Inventroy Updated Successfully");

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

                string Query = "DELETE FROM inventroy WHERE inventroy_id = @id";

                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@id", int.Parse(search.Text));



                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Inventroy Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Inventroy with ID " + int.Parse(id.Text) + " not found.");
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
