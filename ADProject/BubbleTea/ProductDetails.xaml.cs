using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
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
using static BubbleTea.MainWindow;

namespace BubbleTea
{
    /// <summary>
    /// ProductDetails.xaml 的交互逻辑
    /// </summary>
    public partial class ProductDetails : Window
    {
        public ProductDetails()
        {
            InitializeComponent(); 
            EstablishConnect();
            //insertImage();
            // ProductDetails_Load();
           createLabel();
            //productName.Content = SharedVariables.product_name;

        }
        

        public static NpgsqlConnection con;

        public static NpgsqlCommand cmd;

        public static string image_address = "C:\\Users\\zz918\\OneDrive\\Desktop\\ADProject\\BubbleTea\\image\\iceTeaDemo2.png";

        private void ProductDetails_Load(object sender, RoutedEventArgs e)
        {

          
            /*
 try
 {
     EstablishConnect();

     con.Open();

     string Query = "select * from login where product_id = @product_id";

     cmd = new NpgsqlCommand(Query, con);

     cmd.Parameters.AddWithValue("@product_id", SharedVariables.product_id);


     NpgsqlDataReader dr = cmd.ExecuteReader();

     if (!string.IsNullOrEmpty(dr["image_address"].ToString()))
     {

         image_address = dr["image_address"].ToString();


     }
     else
     {
         MessageBox.Show("Image is not avaible");
     }
     con.Close();
 }
 catch (NpgsqlException ex)
 {
     MessageBox.Show(ex.Message);
 }
 */
            //Image_Loaded(image_address);
        }
        private void EstablishConnect()
        {
            try
            {
                con = new NpgsqlConnection(Get_ConnectionString());
               // MessageBox.Show("Connection Established");
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
            string dbName = "Database=ADProject;";
            string userName = "Username=postgres;";
            string password = "Password=123;";

            string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return connectionString;


        }

        /*
        private void Image_Loaded(string imageaddress)
        {

            // ... Create a new BitmapImage.
            try{ 
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(imageaddress,UriKind.Relative);
            b.EndInit();

           
            // ... Assign Source.
            Image.Source = b;
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as invalid image path
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }
        
        private void insertImage()
        {

            Image myImage = new Image();
            myImage.Width = 200;

            // Create source
            BitmapImage myBitmapImage = new BitmapImage();

            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(@"C:\Users\zz918\OneDrive\Desktop\ADProject\BubbleTea\image\iceTeaDemo1.png");

            // To save significant application memory, set the DecodePixelWidth or
            // DecodePixelHeight of the BitmapImage value of the image source to the desired
            // height or width of the rendered image. If you don't do this, the application will
            // cache the image as though it were rendered as its normal size rather than just
            // the size that is displayed.
            // Note: In order to preserve aspect ratio, set DecodePixelWidth
            // or DecodePixelHeight but not both.
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            //set image source
            myImage.Source = myBitmapImage;
           
        }
        */

        public void createLabel()
        {
            Label ProductName = new Label
            {
                Content = SharedVariables.product_name,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 237,
                Height = 40,
                Margin = new Thickness(565, 70, 0, 0),
                Name = "ProductName1",
                FontSize = 14
            };
            myGrid1.Children.Add(ProductName);
           
        }
        //public static readonly List<SharedVariables> orderedProductInfo = new List<>();
        public static string[] orderedProductInfo;

        public static List<string[]> productInfo = new List<string[]>();
        private void addToOrder_Click(object sender, RoutedEventArgs e)
        {
           
            SharedVariables.count++;
            MessageBox.Show($"{SharedVariables.product_name} added to order successfully");
            SharedVariables.sugar = ((ComboBoxItem)sugar.SelectedItem).Content.ToString();
            SharedVariables.ice = ((ComboBoxItem)ice.SelectedItem).Content.ToString();
            SharedVariables.size = ((ComboBoxItem)size.SelectedItem).Content.ToString();
            SharedVariables.quantity = quantity.Text;
           
            if (SharedVariables.size == "Small 236ml")
            {
                SharedVariables.price = 4.69;
            }
            else if (SharedVariables.size == "Medium 354ml")
            {
                SharedVariables.price = 5.99;
            }
            else if (SharedVariables.size == "Large 473ml")
            {
                SharedVariables.price = 6.69;
            }
            else if (SharedVariables.size == "Extra Large 591ml")
            {
                SharedVariables.price = 7.99;
            }
            orderedProductInfo = new string[]{
                SharedVariables.product_id.ToString(),
                SharedVariables.product_name,
                SharedVariables.sugar,
                SharedVariables.ice,
                SharedVariables.quantity,
                SharedVariables.size,
                SharedVariables.count.ToString(),
                SharedVariables.price.ToString()

        };

            productInfo.Add(orderedProductInfo);

           // foreach (var item in productInfo)
           // {
           //     MessageBox.Show(string.Join(", ", item));
          //  }
        }

        private void cart_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.Show();
            this.Close();
        }
    }
}
