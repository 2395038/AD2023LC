using Npgsql;
using System;
using System.Buffers.Text;
using System.CodeDom.Compiler;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
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
using System.Net.Http.Headers;
using Assignment_1.Models;

namespace Assignment_1
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
        
    {
        // we need a REST API client which will help us to communicate with the backend Rest API
        //using System.Net.Http;
        HttpClient client = new HttpClient();
        public Admin()
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
        }
       
        private async void show_Click(object sender, RoutedEventArgs e)
        {
            // step 1 : create/call the method to get all theproducts
            var server_response = await client.GetStringAsync("GetAllProducts");

            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            dataGrid.ItemsSource = response_JSON.products;

            DataContext = this;
        }

        private async void Select_Click(object sender, RoutedEventArgs e)
        {
            // step 1 : create/call the method to get one product
            var server_response =
                await client.GetStringAsync("GetProductbyId/" + int.Parse(search.Text));

            //step 2 : Decryt/extract the server_response
            // import Json libary : using Newtonsoft.Json;
            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

           
            name.Text = response_JSON.product.product_name;
            id.Text = response_JSON.product.product_id.ToString();
            amount.Text = response_JSON.product.product_amount.ToString();
            price.Text = response_JSON.product.product_price.ToString();
          

        }

        private async void insert_Click(object sender, RoutedEventArgs e)
        {
            // stpe 1 : create an instance of the product
            Product product = new Product();

            product.product_name = name.Text;

            MessageBox.Show(product.product_name);

            //Product_ID is not default in database

            product.product_id = int.Parse(id.Text);

           
            if (double.TryParse(amount.Text, out double amountValue))
            {
                product.product_amount = amountValue;
            }

            if (double.TryParse(price.Text, out double priceValue))
            {
                product.product_price = priceValue;
            }
            
                //product.product_amount = Convert.ToDouble(amount.Text);
                 //product.product_price = Convert.ToDouble(price.Text);

            // step 2 : create the instance of the Response class
            //and  send the student using rest api to the remote database
            //server


            //nuGet Package : webAPI
            var server_response =
                await client.PostAsJsonAsync("AddProduct", product);

            MessageBox.Show(server_response.ToString());

            name.Text = null;
            id.Text = null;
            amount.Text = null;
            price.Text = null;
        }

        private async void update_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();

            product.product_name = name.Text;

            if (double.TryParse(amount.Text, out double amountValue))
            {
                product.product_amount = amountValue;
            }

            if (double.TryParse(price.Text, out double priceValue))
            {
                product.product_price = priceValue;
            }

            product.product_id = int.Parse(id.Text);

            var server_response =
                await client.PutAsJsonAsync("UpdateProduct", product);
            MessageBox.Show(server_response.ToString());

            name.Text = null;
            id.Text = null;
            amount.Text = null;
            price.Text = null;
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var response_JSON =
                await client.DeleteAsync("DeleteProductbyId/"
                + int.Parse(search.Text));

            MessageBox.Show(response_JSON.StatusCode.ToString());
            MessageBox.Show(response_JSON.RequestMessage.ToString());

        }

       
    }
}
