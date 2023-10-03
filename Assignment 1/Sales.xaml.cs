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

namespace Assignment_1
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        public Sales()
        {
            InitializeComponent();
        }

        private void Calculate_Total_Click(object sender, RoutedEventArgs e)
        {
            double appleAmount = 0;
            double applePrice = 0.0;

            double orangeAmount = 0;
            double orangePrice = 0.0;

            double raspberryAmount = 0;
            double raspberryPrice = 0.0;

            double blueberryAmount = 0;
            double blueberryPrice = 0.0;

            double cauliflowerAmount = 0;
            double cauliflowerPrice = 0.0;

            double otherAmount = 0;
            double otherPrice = 0.0;

            
            if (!string.IsNullOrEmpty(Amount1.Text))
            {
                appleAmount = double.Parse(Amount1.Text);
                applePrice = double.Parse(Price1.Text);
            }

            if (!string.IsNullOrEmpty(Amount2.Text))
            {
                orangeAmount = double.Parse(Amount2.Text);
                orangePrice = double.Parse(Price2.Text);
            }

            if (!string.IsNullOrEmpty(Amount3.Text))
            {
                raspberryAmount = double.Parse(Amount3.Text);
                raspberryPrice = double.Parse(Price3.Text);
            }

            if (!string.IsNullOrEmpty(Amount4.Text))
            {
                blueberryAmount = double.Parse(Amount4.Text);
                blueberryPrice = double.Parse(Price4.Text);
            }

            if (!string.IsNullOrEmpty(Amount5.Text))
            {
                cauliflowerAmount = double.Parse(Amount5.Text);
                cauliflowerPrice = double.Parse(Price5.Text);
            }

            if (!string.IsNullOrEmpty(Amount6.Text))
            {
                otherAmount = double.Parse(Amount6.Text);
                otherPrice = double.Parse(Price6.Text);
            }

            
            double total = appleAmount * applePrice + orangeAmount * orangePrice +
                           raspberryAmount * raspberryPrice + blueberryAmount * blueberryPrice +
                           cauliflowerAmount * cauliflowerPrice + otherAmount * otherPrice;

            MessageBox.Show("Total is " + total);
        }
        }
}
