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
    public partial class Basket : Window
    {
        public string username = "";
        public string order_content = "";
        public Basket(string Username)
        {
            InitializeComponent();
            username = Username;
        }
        public string TrimString(string str)
        {
            String stroke = str;
            char[] chars = { '₽' };
            string correct_str = stroke.TrimEnd(chars);

            return correct_str;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DB db = new DB();

            try
            {
                long basket_item_count = await db.GetCountBasketItem(username);
                float last_price = await db.GetPriceBasketItems(username);

                lastPriceL.Content = last_price.ToString() + "₽";

                for (int i = 1; i <= basket_item_count; i++)
                {
                    var basket_item = await db.GetBasketItem(i, username);

                    if (basket_item != null)
                    {
                        BasketEx basket = new BasketEx(basket_item.Image, basket_item.Name, basket_item.Count, basket_item.End_Price, false);

                        order_content += basket_item.Id_Item + ",";

                        string correct_price = TrimString(basket_item.Start_Price.ToString());

                        basket.inc_btn.Click += (s, e) =>
                        {
                            int count = Convert.ToInt32(basket.count_label.Content);

                            if (count < 10)
                            {
                                string correct_chena = TrimString(basket.price_label.Content.ToString());
                                int start_count = count;

                                count++;

                                basket.price_label.Content = (count * Convert.ToInt32(correct_price)).ToString();
                                basket.count_label.Content = count.ToString();

                                string l_p = TrimString(lastPriceL.Content.ToString());

                                lastPriceL.Content = ((Convert.ToSingle(l_p) - Convert.ToSingle(correct_chena)) + Convert.ToSingle(basket.price_label.Content)).ToString();

                                lastPriceL.Content += "₽";
                                basket.price_label.Content += "₽";
                            }
                        };
                        basket.dec_btn.Click += (s, e) =>
                        {
                            int count = Convert.ToInt32(basket.count_label.Content);

                            if (count > 1)
                            {
                                string correct_chena = TrimString(basket.price_label.Content.ToString());
                                int start_count = count;

                                count--;

                                basket.price_label.Content = (count * Convert.ToInt32(correct_price)).ToString();
                                basket.count_label.Content = count.ToString();

                                string l_p = TrimString(lastPriceL.Content.ToString());

                                lastPriceL.Content = ((Convert.ToSingle(l_p) - Convert.ToSingle(correct_chena)) + Convert.ToSingle(basket.price_label.Content)).ToString();

                                lastPriceL.Content += "₽";
                                basket.price_label.Content += "₽";
                            }
                        };

                        listView.Items.Add(basket.stack);
                    }
                }
            }
            catch
            {
                lastPriceL.Content = "0₽";
                MessageBox.Show("Корзина пуста, добавьте товары, чтобы продолжить");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu(username);
            menu.Show();
            Hide();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            float summ = Convert.ToSingle(TrimString(lastPriceL.Content.ToString()));

            DB db = new DB();

            MessageBoxResult result = MessageBox.Show("Вы хотите оформить заказ?", "Оформление заказа", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Заказ успешно добавлен!");
                await db.AddOrder(summ, order_content, username);
                await db.ClearBasket(username);

                Orders orders = new Orders(username);
                orders.Show();
                this.Hide();
            }
        }
    }
}
