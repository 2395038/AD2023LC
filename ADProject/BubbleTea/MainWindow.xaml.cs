using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static BubbleTea.ProductDetails;

namespace BubbleTea
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeLogin employeeLogin = new EmployeeLogin();

            employeeLogin.Show();

            
        }
        
        private void login_Click(object sender, RoutedEventArgs e)
        {
            EmployeeLogin login = new EmployeeLogin();
            login.Show();
           

            
        }

        private void iceTea1_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 1;
            SharedVariables.product_name = iceTea1.Content.ToString();
            
        }

        private void iceTea2_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 2;
            SharedVariables.product_name = iceTea2.Content.ToString();
        }

        private void iceTea3_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 3;
            SharedVariables.product_name = iceTea3.Content.ToString();
        }

        private void iceTea4_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 4;
            SharedVariables.product_name = iceTea4.Content.ToString();
        }

        private void iceTea5_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 5;
            SharedVariables.product_name = iceTea5.Content.ToString();
        }

        private void iceTea6_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 6;
            SharedVariables.product_name = iceTea6.Content.ToString();
        }

        private void iceTea7_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 7;
            SharedVariables.product_name = iceTea7.Content.ToString();
        }

        private void iceTea8_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 8;
            SharedVariables.product_name = iceTea8.Content.ToString();
        }

        private void milkTea1_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 9;
            SharedVariables.product_name = milkTea1.Content.ToString();
        }

        private void milkTea2_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 10;
            SharedVariables.product_name = milkTea2.Content.ToString();
        }

        private void milkTea3_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 11;
            SharedVariables.product_name = milkTea3.Content.ToString();

        }

        private void milkTea4_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 12;
            SharedVariables.product_name = milkTea4.Content.ToString();
        }

        private void milkTea5_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 13;
            SharedVariables.product_name = milkTea5.Content.ToString();
        }

        private void milkTea6_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 14;
            SharedVariables.product_name = milkTea6.Content.ToString();
        }

        private void milkTea7_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 15;
            SharedVariables.product_name = milkTea7.Content.ToString();
        }

        private void milkTea8_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails details = new ProductDetails();
            details.Show();
            SharedVariables.product_id = 16;
            SharedVariables.product_name = milkTea8.Content.ToString();
        }
    }
}


