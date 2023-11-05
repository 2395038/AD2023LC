using ShoppingCart_UnitTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
  
    public partial class MainWindow : Window
    {
        private ShoppingCart sc { get; set; } = null;

        public MainWindow() {
            
            sc = new ShoppingCart();
            //InitializeComponent();
        }
    
        
        private void checkout_Click(object sender, RoutedEventArgs e)
        {
            int q = int.Parse(quantity1.Text);
            double p = double.Parse(price1.Text);

            double totalAmount = sc.getCheckOut(q, p);

            MessageBox.Show("Total Amount is $" + totalAmount);

        }


    }
}