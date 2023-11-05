using Microsoft.SqlServer.Server;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BubbleTea
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

       

        private void select_Click(object sender, RoutedEventArgs e)
        {
            if (radio1.IsChecked == true)
            {
                // Create an instance of Form1
                EmployeeMangment  employeMangment = new EmployeeMangment();

                // Show Form1
                employeMangment.Show();
            }
            else if (radio2.IsChecked == true)
            {
                Inventroy   inventroy = new Inventroy();    
                inventroy.Show();
            }
            else if (radio3.IsChecked == true)
            {
                Product product = new Product();    
                product.Show();
            }
            else { 
            // Handle the case when radioButton1 is not selected
            MessageBox.Show("Please select radioButton1 to open Form1.");
            }
        }

     
    }
}
