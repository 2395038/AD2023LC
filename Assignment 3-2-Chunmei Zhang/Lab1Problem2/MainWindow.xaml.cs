using Lab1Problem2.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1Problem2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalcCharges gc { get; set; } = null;
        public MainWindow()
        {
            gc = new CalcCharges();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double weightOfPackage = double.Parse(WOP.Text);
            double mileage = double.Parse(M.Text);

            MessageBox.Show("The total shipping charges is " + gc.getCharges(weightOfPackage, mileage) + "$");
        }
    }
}
