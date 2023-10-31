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

namespace Assignment_1
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        HttpClient client = new HttpClient();
        public Admin()
        {
            client.BaseAddress = new Uri("https://localhost:7258/Product/"); //此处要看网页API

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            InitializeComponent();
        }

        private async void show_Click(object sender, RoutedEventArgs e)
        {
            
            var server_response = await client.GetStringAsync("GetAllProducts");

            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            dataGrid.ItemsSource = response_JSON.products;

            DataContext = this;
        }

        private async void Select_Click(object sender, RoutedEventArgs e)
        {
            var server_response =
                await client.GetStringAsync("GetProductbyId/" + int.Parse(search.Text));

            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            name.Text = response_JSON.product.product_name;
            id.Text = response_JSON.product.product_id.ToString();
            amount.Text = response_JSON.product.product_amount.ToString();
            price.Text = response_JSON.product.product_price.ToString();
            year.Text = response_JSON.product.product_year.ToString();

        }

        private async void insert_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();

            product.product_name = name.Text;
            product.product_amount = amount.Text;
            product.product_price = price.Text;
            product.product_date = int.Parse(year.Text);

            var server_response =
                await client.PostAsJsonAsync("AddProduct", product);

            MessageBox.Show(server_response.ToString());
        }

        private async void update_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.product_name = name.Text;
            product.product_amount = amount.Text;
            product.product_price = price.Text;
            product.product_date = int.Parse(year.Text);
            product.product_id = int.Parse(id.Text);

            var server_response =
                await client.PutAsJsonAsync("UpdateProduct", product);
            MessageBox.Show(server_response.ToString());
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
