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
    /// <summary>
    /// ShoppingCart.xaml 的交互逻辑
    /// </summary>
    public partial class ShoppingCart : Window
    {
        public ShoppingCart()
        {
            InitializeComponent();
            addNewLabel();
            
        }
        List<string[]> productInfo = ProductDetails.productInfo;
        private List<Label> dynamicLabels = new List<Label>();
        private void addNewLabel()

        {
            int num = 30;
           

            Label OrderID_label = new Label
            {
                Content = "No.",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(350, 60 , 0, 0),
                Name = "numlb",
                FontSize = 14

            };
            Label ProductName_label = new Label
            {
                Content = "  Tea    ",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(385, 60, 0, 0),
                Name = "productNamelb",
                FontSize = 14

            };

            Label sugar_label = new Label
            {
                Content = "Sugar",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(580, 60, 0, 0),
                Name = "sugarlb",
                FontSize = 14

            };
            Label ice_label = new Label
            {
                Content = "Ice",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(630, 60, 0, 0),
                Name = "icelb",
                FontSize = 14

            };
            Label size_label = new Label
            {
                Content = "Size",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(700, 60, 0, 0),
                Name = "sizelb",
                FontSize = 14

            };
            Label quantity_label = new Label
            {
                Content = "Quantity",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(830, 60, 0, 0),
                Name = "quantitylb",
                FontSize = 14

            };
            Label price_label = new Label
            {
                Content = "  Price",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(880, 60, 0, 0),
                Name = "pricelb",
                FontSize = 14

            };

            myGrid.Children.Add(ProductName_label);
            myGrid.Children.Add(OrderID_label);
            myGrid.Children.Add(sugar_label);
            myGrid.Children.Add(ice_label);
            myGrid.Children.Add(size_label);
            myGrid.Children.Add(quantity_label);
            myGrid.Children.Add(price_label);


            for (int i = 0; i < productInfo.Count; i++)
            {
                num += 30;
                Label OrderID_lb = new Label
                {
                    Content = i+1,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(350, 30+num, 0, 0),
                    Name = "numlb" + i,
                    FontSize = 14

                };
                Label ProductName_lb = new Label
                {
                    Content = productInfo[i][1],
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(385, 30 + num, 0, 0),
                    Name = "productNamelb" + i,
                    FontSize = 14

                };

                Label sugar_lb = new Label
                {
                    Content = productInfo[i][2],
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(580, 30 + num, 0, 0),
                    Name = "sugarlb" + i,
                    FontSize = 14

                };
                Label ice_lb = new Label
                {
                    Content = productInfo[i][3],
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(630, 30 + num, 0, 0),
                    Name = "icelb" + i,
                    FontSize = 14

                };
                Label size_lb = new Label
                {
                    Content = productInfo[i][5],
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(700, 30 + num, 0, 0),
                    Name = "sizelb" + i,
                    FontSize = 14

                };
                Label quantity_lb = new Label
                {
                    Content = productInfo[i][4],
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(830, 30 + num, 0, 0),
                    Name = "quantitylb" + i,
                    FontSize = 14

                };
                Label price_lb = new Label
                {
                    Content = productInfo[i][7],
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(880, 30 + num, 0, 0),
                    Name = "pricelb" + i,
                    FontSize = 14

                };
                myGrid.Children.Add(OrderID_lb);
                myGrid.Children.Add(ProductName_lb);
                myGrid.Children.Add(sugar_lb);
                myGrid.Children.Add(ice_lb);
                myGrid.Children.Add(size_lb);
                myGrid.Children.Add(quantity_lb);
                myGrid.Children.Add(price_lb);

                dynamicLabels.Add(OrderID_lb);
                dynamicLabels.Add(ProductName_lb);
                dynamicLabels.Add(sugar_lb);
                dynamicLabels.Add(ice_lb);
                dynamicLabels.Add(size_lb);
                dynamicLabels.Add(quantity_lb);
                dynamicLabels.Add(price_lb);



            }
            dynamicLabels.Add(OrderID_label);
            dynamicLabels.Add(ProductName_label);
            dynamicLabels.Add(sugar_label);
            dynamicLabels.Add(ice_label);
            dynamicLabels.Add(size_label);
            dynamicLabels.Add(quantity_label);
            dynamicLabels.Add(price_label);
        }

        private void checkout_Click(object sender, RoutedEventArgs e)
        {
            //1. cal totol amount
            double totalAmount = 0;
            for(int i = 0; i < productInfo.Count; i++)
            {
                totalAmount += double.Parse(productInfo[i][7]);

            }
            MessageBox.Show("Total Amount is $" +totalAmount);
            
            //2. remove all the label controls that created 
            foreach (var label in dynamicLabels)
            {
                myGrid.Children.Remove(label);
            }
            // Clear the list
            dynamicLabels.Clear();


        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

