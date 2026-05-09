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

namespace Konditer
{
    public partial class Menu : Window
    {
        public string username = "";
        public Menu(string Username)
        {
            username = Username;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //exit
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //profile
        {
            Profile profile = new Profile(username);
            profile.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //order
        {
            Orders orders = new Orders(username);
            orders.Show();
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //product
        {
            Product product = new Product(username);
            product.Show();
            this.Hide();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e) //basket
        {
            Basket basket = new Basket(username);
            basket.Show();
            this.Hide();
        }
    }
}
