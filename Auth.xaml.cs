using Konditer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Xamarin.Essentials;

namespace Konditer
{
    public partial class Auth : Window
    {
        DB db = new DB();
        public Auth()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e) //auth
        {
            string Username = usernameBox.Text;
            string Password = passBox.Password;

            if (Username == null || Password == null)
                MessageBox.Show("Одно из полей пустое, заполните поля и повторите попытку");
            else
            {
                try
                {
                    var user = await db.GetUser(Username);

                    if (user != null)
                    {
                        if (user.Username == Username && user.Password == Password && user.Role == "Пользователь")
                        {
                            MessageBox.Show("Авторизация прошла успешно!");
                            Menu menu = new Menu(user.Username);
                            menu.Show();
                            Hide();
                        }
                        else if(user.Username == Username && user.Password == Password && user.Role == "Администратор")
                        {
                            MessageBox.Show("Авторизация прошла успешно!");
                            Menu_admin menu = new Menu_admin(user.Username);
                            menu.Show();
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка, попробуйте позже!");
                }
            }
        }
        private void Label_MouseDown(object sender, MouseButtonEventArgs e) // reg
        {
            Register reg = new Register();
            reg.Show();
        }
    }
}
