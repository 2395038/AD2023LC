using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Assignment_1
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {

        public static NpgsqlConnection con;

        public static NpgsqlCommand cmd;
        public Sales()
        {
            InitializeComponent();
            refreshPage();
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
            string password = "Password=123;";

            string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return connectionString;


        }

        private void Calculate_Total_Click(object sender, RoutedEventArgs e)
        {
            double totalAmount=0;
            int count = 0;
            List<UIElement> controlstb = new List<UIElement>();
            List<UIElement> controlslb = new List<UIElement>();
            foreach (UIElement ctrl in myGrid.Children)
            {
                if (ctrl is TextBox)
                {
                    controlstb.Add(ctrl);
                    count++;

                }
                else if (ctrl is Label)
                {
                    Label pricelb = (Label)ctrl;
                    if (pricelb.Name.Contains("pricelb"))
                    {
                        controlslb.Add(ctrl);
                    }

                }

            }
            MessageBox.Show(count.ToString());
            for (int i = 0; i < count; i++)
            {
                TextBox txtbox = (TextBox)controlstb[i];
                Label lb = (Label)controlslb[i];
                if (!string.IsNullOrEmpty(txtbox.Text) && double.TryParse(txtbox.Text, out double textBoxValue) && double.TryParse(lb.Content.ToString(), out double lbValue))
                {
                    totalAmount += textBoxValue * lbValue;
                }

            }

            MessageBox.Show("Total is " + totalAmount.ToString("C"));
        }

        private void checkout_Click(object sender, RoutedEventArgs e)

        {

            int count = 0;
            List<UIElement> controlstb = new List<UIElement>();
            List<UIElement> controlslb = new List<UIElement>();
            foreach (UIElement ctrl in myGrid.Children)
            {
                if (ctrl is TextBox)
                {
                    controlstb.Add(ctrl);
                    count++;

                }
                else if (ctrl is Label)
                {
                    Label ProductNamelb = (Label)ctrl;
                    if (ProductNamelb.Name.Contains("productlb"))
                    {
                        controlslb.Add(ctrl);
                    }

                }

            }

            try
            {

                establishConnect();

                con.Open();

                for (int i = 0; i < count; i++)
                {
                    string Query = "UPDATE products SET Amount =Amount - @amount WHERE Product_Name = @name";

                    cmd = new NpgsqlCommand(Query, con);

                    TextBox txtbox = (TextBox)controlstb[i];
                    Label lb = (Label)controlslb[i];

                    if (!string.IsNullOrEmpty(txtbox.Text) && double.TryParse(txtbox.Text, out double textBoxValue))
                    {
                        cmd.Parameters.AddWithValue("@name", lb.Content.ToString());
                        cmd.Parameters.AddWithValue("@amount", double.Parse(txtbox.Text));
                    }

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Product Amount Updated Successfully");

                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            refreshPage();
        }

        
        private void refreshPage()
        {
            //int numberOfRecords = 0;
            try
            {
                establishConnect();

                con.Open();

                string Query = "select * from products";

                cmd = new NpgsqlCommand(Query, con);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);
                //numberOfRecords=dt.Rows.Count;

                //MessageBox.Show("Loading all data");

                con.Close();

                List<UIElement> controls = new List<UIElement>();
                foreach (UIElement ctrl in myGrid.Children)
                {
                    if (ctrl is Label || ctrl is TextBox)
                    {
                        controls.Add(ctrl);
                    }

                }

                foreach (UIElement ctrl in controls)
                {
                    myGrid.Children.Remove(ctrl);
                }



                int num1 = 30;
                int num2 = 30;
                int num3 = 30;
                Label ProductName_label = new Label
                {
                    Content = "Product Name",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(400, 30, 0, 0),
                    Name = "productNamelb",
                    FontSize = 14

                };
                Label Amount_label = new Label
                {
                    Content = "Amount(kg)",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(550, 30, 0, 0),
                    Name = "amountlb",
                    FontSize = 14

                };


                Label PriceList_label = new Label
                {
                    Content = "Price(CAD/kg)",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(700, 30, 0, 0),
                    Name = "pricelistlb",
                    FontSize = 14

                };

                myGrid.Children.Add(ProductName_label);
                myGrid.Children.Add(PriceList_label);
                myGrid.Children.Add(Amount_label);

                foreach (DataRow row in dt.Rows)
                {
                    int i = 0;

                    string productName = row["Product_Name"].ToString();

                    string price = row["Price"].ToString();

                    Label Product_label = new Label
                    {
                        Content = productName,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(400, num1 += 30, 0, 0),
                        Name = "productlb" + i

                    };

                    TextBox amount = new TextBox
                    {

                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(550, num3 += 30, 0, 0),
                        Name = "Amount" + i,
                        Width = 88

                    };

                    Label Price_label = new Label
                    {
                        Content = price,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(700, num2 += 30, 0, 0),
                        Name = "pricelb" + i

                    };
                    myGrid.Children.Add(Product_label);
                    myGrid.Children.Add(Price_label);
                    myGrid.Children.Add(amount);

                }



            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    


    
}
