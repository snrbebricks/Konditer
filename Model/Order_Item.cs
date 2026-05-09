using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Konditer.Model
{
    public class Order_Item
    {
        public StackPanel stack = new StackPanel();
        public Grid grid = new Grid();
        public Order_Item(int order_num, string order_date, float order_price) 
        {
            stack.Height = 100;
            stack.Width = 330;
            stack.Margin = new Thickness(0, 5, 0, 5);

            grid.Height = 100;
            grid.Width = 330;

            Label num_order = new Label
            {
                Content = "Заказ #" + order_num.ToString(),
                Margin = new Thickness(10, 3, 165, -3),
                FontSize = 22,
                FontWeight = FontWeights.Bold,
            };

            Label price = new Label
            {
                Content = order_price.ToString() + "₽",
                Margin = new Thickness(10, 47, 165, -47),
                FontSize = 18,
                FontWeight = FontWeights.Bold,
            };

            Label date = new Label
            {
                Content = order_date,
                Margin = new Thickness(227, 7, -49, -9),
                FontSize = 18,
                FontWeight = FontWeights.Bold,
            };

            grid.Children.Add(num_order);
            grid.Children.Add(price);
            grid.Children.Add(date);

            stack.Children.Add(grid);
        }
    }
}
