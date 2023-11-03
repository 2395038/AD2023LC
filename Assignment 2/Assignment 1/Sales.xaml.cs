using Assignment_1.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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
using System.Text.Json;
namespace Assignment_1
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        HttpClient client = new HttpClient();

        public Sales()
        {
            //initialize the client with the Rest API connection with proper server initializtion 

            // step 1 : Setup the base address for our created Rest API

            client.BaseAddress = new Uri("https://localhost:7058/ProductManagementControler/"); //check web address by running RestAPIAssigment2

            // step 2 : we need to clear the default network packet header information 

            client.DefaultRequestHeaders.Accept.Clear();

            // step 3 : add our packet information to the http request 
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            InitializeComponent();
            refreshPage();
        }
        public static class MyStaticClass
        {
            // Static list
            public static List<double> amountList = new List<double>();
            public static List<int> idList = new List<int>();
            public static List<double> priceList= new List<double>();
            // Static method to manipulate the static list
            public static void AddToAmounList(double value)
            {
                amountList.Add(value);
            }
            public static void AddToIdList(int value)
            {
                idList.Add(value);
            }
            public static void AddToPriceList(double value)
            {
                priceList.Add(value);
            }
        }

        private void Calculate_Total_Click(object sender, RoutedEventArgs e)
        {
            double totalAmount = 0;
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

        private async void checkout_Click(object sender, RoutedEventArgs e)

        {
            // conncet to API and retrive data 

          


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

            for (int i = 0; i < count; i++)
            {
                TextBox txtbox = (TextBox)controlstb[i];
                Label lb = (Label)controlslb[i];


                if (!string.IsNullOrEmpty(txtbox.Text) && double.TryParse(txtbox.Text, out double textBoxValue))
                {
                    Product product = new Product();

                    product.product_name = lb.Content.ToString();

                    if (double.TryParse(txtbox.Text, out double amountValue))
                    {
                        product.product_amount = MyStaticClass.amountList[i] - amountValue;
                    }

                    product.product_id = MyStaticClass.idList[i];
                    MessageBox.Show(MyStaticClass.idList[i].ToString() );

                    product.product_price = MyStaticClass.priceList[i];

                    var server_response =
                        await client.PutAsJsonAsync("UpdateProduct", product);
                    MessageBox.Show(server_response.ToString());
                }

           
            }
            MessageBox.Show("Product Amount Updated Successfully");




        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            refreshPage();
        }


        private async void refreshPage()
          {
                // clear the old data 

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


                // conncet to API and retrive data 

                var server_response = await client.GetStringAsync("GetAllProducts");

                Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

               



            // draw user interface
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

                   double newAmount = 0;
            //List<Double> amountList = new List<Double>();
                    int newId = 0; 
                    double newPrice = 0;
            // fill the data with API response 
            foreach (Product product in response_JSON.products)
                  {
                      int i = 0;

                      string productName = product.product_name.ToString();

                      string price = product.product_price.ToString();

                      newAmount = product.product_amount;
                      newId=product.product_id;
                      newPrice = product.product_price;
                    MyStaticClass.AddToAmounList(newAmount);
                    MyStaticClass.AddToIdList(newId);
                    MyStaticClass.AddToPriceList(newPrice);

                // test static list
               // MessageBox.Show(MyStaticClass.idList[0].ToString());


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

      
    } 
    }



    

