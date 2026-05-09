using Konditer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using Xamarin.Essentials;

namespace Konditer
{
    public partial class Orders : Window
    {
        public string username = "";
        public Orders(string Username)
        {
            InitializeComponent();
            username = Username;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DB db = new DB();

            try
            {
                long order_count = await db.GetCountOrderItem(username);

                for (int i = 1; i <= order_count; i++)
                {
                    var order_item = await db.GetOrderItem(i, username);

                    if (order_item != null)
                    {
                        Order_Item order = new Order_Item(order_item.Id, order_item.Date, order_item.Summ);

                        order.stack.MouseDown += (s, e) =>
                        {
                            OrderContent order_cont = new OrderContent(username, order_item.Id, order_item.Summ, order_item.Id_items);
                            order_cont.Show();
                            this.Hide();
                        };

                        listView.Items.Add(order.stack);
                    }
                }
            }
            catch
            {
                MessageBox.Show("История заказов пуста, оформите заказы, чтобы продолжить");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) //prev menu
        {
            Menu menu = new Menu(username);
            menu.Show();
            this.Hide();
        }
    }
}
