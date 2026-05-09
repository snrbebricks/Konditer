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

namespace Konditer
{
    public partial class OrderContent : Window
    {
        public string username = "";
        public int order_id = 0;
        public float price = 0;
        public string id_items = "";
        public OrderContent(string Username, int Id_order, float summ, string id_item)
        {
            InitializeComponent();
            username = Username;
            order_id = Id_order;
            price = summ;
            id_items = id_item;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DB db = new DB();

            try
            {
                priceL.Content = price.ToString() + "₽";

                string[] id_item = id_items.Split(',');
                for (int i = 0; i < id_item.Length - 1; i++)
                {
                    int id = Convert.ToInt32(id_item[i]);
                    var basket_item = await db.GetOrderContentItem(id);

                    if (basket_item != null)
                    {
                        BasketEx basket = new BasketEx(basket_item.Image, basket_item.Name, 0, 0, true);

                        listView.Items.Add(basket.stack);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка, попробуйте позже");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Orders menu = new Orders(username);
            menu.Show();
            this.Hide();
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DB db = new DB();

            MessageBoxResult result = MessageBox.Show("Вы хотите удалить заказ?", "Удаление заказа", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                await db.DeleteOrder(order_id, username);
                Orders menu = new Orders(username);
                menu.Show();
                this.Hide();
            }
        }
    }
}
