using Konditer.Model;
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
    public partial class Product : Window
    {
        public string username = "";
        public Product(string Username)
        {
            InitializeComponent();
            username = Username;
        }

        private async void Button_Click(object sender, RoutedEventArgs e) //milk 3.2
        {
            try
            {
                DB db = new DB();

                var basket_item = await db.GetBasketItem(7, username);

                if (basket_item == null)
                {
                    await db.AddBasketItem(7, 1, 69, 69, username);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
                else if (basket_item != null)
                {
                    int count = basket_item.Count + 1;
                    float last_price = basket_item.End_Price + basket_item.Start_Price;
                    await db.AddMoreBasketItem(count, last_price, 7);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
            }
            catch
            {
                MessageBox.Show("При добавлении товара произошла ошибка, попробуйте позже!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //prev
        {
            Menu menu = new Menu(username);
            menu.Show();
            this.Hide();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e) //milk 2.5
        {
            try
            {
                DB db = new DB();

                var basket_item = await db.GetBasketItem(6, username);

                if (basket_item == null)
                {
                    await db.AddBasketItem(6, 1, 55, 55, username);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
                else if (basket_item != null)
                {
                    int count = basket_item.Count + 1;
                    float last_price = basket_item.End_Price + basket_item.Start_Price;
                    await db.AddMoreBasketItem(count, last_price, 6);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
            }
            catch
            {
                MessageBox.Show("При добавлении товара произошла ошибка, попробуйте позже!");
            }
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e) //egg1
        {
            try
            {
                DB db = new DB();

                var basket_item = await db.GetBasketItem(4, username);

                if (basket_item == null)
                {
                    await db.AddBasketItem(4, 1, 165, 165, username);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
                else if (basket_item != null)
                {
                    int count = basket_item.Count + 1;
                    float last_price = basket_item.End_Price + basket_item.Start_Price;
                    await db.AddMoreBasketItem(count, last_price, 4);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
            }
            catch
            {
                MessageBox.Show("При добавлении товара произошла ошибка, попробуйте позже!");
            }
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e) //egg2
        {
            try
            {
                DB db = new DB();

                var basket_item = await db.GetBasketItem(5, username);

                if (basket_item == null)
                {
                    await db.AddBasketItem(5, 1, 139, 139, username);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
                else if (basket_item != null)
                {
                    int count = basket_item.Count + 1;
                    float last_price = basket_item.End_Price + basket_item.Start_Price;
                    await db.AddMoreBasketItem(count, last_price, 5);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
            }
            catch
            {
                MessageBox.Show("При добавлении товара произошла ошибка, попробуйте позже!");
            }
        }

        private async void Button_Click_5(object sender, RoutedEventArgs e) //tomato1
        {
            try
            {
                DB db = new DB();

                var basket_item = await db.GetBasketItem(1, username);

                if (basket_item == null)
                {
                    await db.AddBasketItem(1, 1, 189, 189, username);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
                else if (basket_item != null)
                {
                    int count = basket_item.Count + 1;
                    float last_price = basket_item.End_Price + basket_item.Start_Price;
                    await db.AddMoreBasketItem(count, last_price, 1);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
            }
            catch
            {
                MessageBox.Show("При добавлении товара произошла ошибка, попробуйте позже!");
            }
        }

        private async void Button_Click_6(object sender, RoutedEventArgs e) //tomato2
        {
            try
            {
                DB db = new DB();

                var basket_item = await db.GetBasketItem(2, username);

                if (basket_item == null)
                {
                    await db.AddBasketItem(2, 1, 231, 231, username);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
                else if (basket_item != null)
                {
                    int count = basket_item.Count + 1;
                    float last_price = basket_item.End_Price + basket_item.Start_Price;
                    await db.AddMoreBasketItem(count, last_price, 2);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
            }
            catch
            {
                MessageBox.Show("При добавлении товара произошла ошибка, попробуйте позже!");
            }
        }

        private async void Button_Click_7(object sender, RoutedEventArgs e) //chik1
        {
            try
            {
                DB db = new DB();

                var basket_item = await db.GetBasketItem(8, username);

                if (basket_item == null)
                {
                    await db.AddBasketItem(8, 1, 532, 532, username);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
                else if (basket_item != null)
                {
                    int count = basket_item.Count + 1;
                    float last_price = basket_item.End_Price + basket_item.Start_Price;
                    await db.AddMoreBasketItem(count, last_price, 8);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
            }
            catch
            {
                MessageBox.Show("При добавлении товара произошла ошибка, попробуйте позже!");
            }
        }

        private async void Button_Click_8(object sender, RoutedEventArgs e) //chik2
        {
            try
            {
                DB db = new DB();

                var basket_item = await db.GetBasketItem(9, username);

                if (basket_item == null)
                {
                    await db.AddBasketItem(9, 1, 324, 324, username);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
                else if (basket_item != null)
                {
                    int count = basket_item.Count + 1;
                    float last_price = basket_item.End_Price + basket_item.Start_Price;
                    await db.AddMoreBasketItem(count, last_price, 9);
                    MessageBox.Show("Товар успешно добавлен в корзину!");
                }
            }
            catch
            {
                MessageBox.Show("При добавлении товара произошла ошибка, попробуйте позже!");
            }
        }
    }
}
