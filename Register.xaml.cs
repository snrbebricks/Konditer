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
    public partial class Register : Window
    {
        DB db = new DB();
        public Register()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string Username = usernameBox.Text;
            string Password = passwordBox.Text;
            string first_name = firstBox.Text;
            string name = nameBox.Text;
            string last_name = lastBox.Text;
            string email = emailBox.Text;
            string phone = numberBox.Text;

            if (Username != null && Password != null && first_name != null && name != null && last_name != null && email != null && phone != null)
            {
                try
                {
                    var user = await db.GetUser(Username);
                    if (user == null)
                    {
                        if (Username.Length < 3 || Password.Length < 3 || Password.Length > 10)
                        {
                            MessageBox.Show("Поле 'Логин' должно содержать минимум 3 символа, а поле 'Пароль' минимум 3 и максимум 10 символов!");
                        }
                        else
                        {
                            try
                            {
                                await db.Add_User(new User { Username = Username, Password = Password, Role = "Пользователь", First_name = first_name, Name = name, Last_name = last_name, Email = email, Number = phone });
                                MessageBox.Show("Регистрация прошла успешно! Вы можете авторизироваться!");
                                this.Close();
                            }
                            catch
                            {
                                MessageBox.Show("Произошла ошибка при регистрации, повторите попытку позже :(");
                            }
                        }
                    }
                    else
                        MessageBox.Show("К сожалению, введенное вами имя уже занято!");
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка, попробуйте позже!");
                }
            }
            else
                MessageBox.Show("Пожалуйста, заполните все поля!");
        }
    }
}
