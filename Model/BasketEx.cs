using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Konditer.Model
{
    public class BasketEx
    {
        public StackPanel stack = new StackPanel();
        public Grid grid = new Grid();
        public Button inc_btn = new Button();
        public Button dec_btn = new Button();
        public Label price_label = new Label();
        public Label count_label = new Label();

        public BasketEx(string image, string name, int count, float price, bool isOrder)
        {
            stack.Height = 100;
            stack.Width = 272;
            stack.Margin = new Thickness(0, 5, 0, 5);

            grid.Height = 100;
            grid.Width = 272;

            Image img = new Image
            {
                Source = new BitmapImage(new Uri(image, UriKind.Relative)),
                Height = 80,
                Margin = new Thickness(6, 10, 186, 10)
            };

            Label names = new Label
            {
                Content = name,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(86, 16, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                FontSize = 12
            };

            if (!isOrder)
            {
                inc_btn.Content = "+";
                inc_btn.Margin = new Thickness(150, 70, 0, 0);
                inc_btn.Width = 20;
                inc_btn.Height = 20;
                inc_btn.HorizontalAlignment = HorizontalAlignment.Left;
                inc_btn.VerticalAlignment = VerticalAlignment.Top;

                dec_btn.Content = "-";
                dec_btn.Margin = new Thickness(91, 70, 0, 0);
                dec_btn.Width = 20;
                dec_btn.Height = 20;
                dec_btn.HorizontalAlignment = HorizontalAlignment.Left;
                dec_btn.VerticalAlignment = VerticalAlignment.Top;

                count_label.Content = count.ToString();
                count_label.Margin = new Thickness(116, 67, 130, 3);

                price_label.Content = price.ToString();
                price_label.Margin = new Thickness(224, 10, 0, 0);
                price_label.HorizontalAlignment = HorizontalAlignment.Left;
                price_label.VerticalAlignment = VerticalAlignment.Top;
                price_label.FontWeight = FontWeights.Bold;

                grid.Children.Add(inc_btn);
                grid.Children.Add(dec_btn);
                grid.Children.Add(count_label);
                grid.Children.Add(price_label);
            }

            grid.Children.Add(img);
            grid.Children.Add(names);

            stack.Children.Add(grid);
        }
    }
}
