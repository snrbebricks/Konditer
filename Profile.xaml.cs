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
    public partial class Profile : Window
    {
        public bool isEdit = false;
        public string username = "";
        public Profile(string Username)
        {
            InitializeComponent();
            username = Username;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DB db = new DB();

            isEdit = false;

            firstLabel.IsEnabled = false;
            nameLabel.IsEnabled = false;
            lastLabel.IsEnabled = false;
            mailLabel.IsEnabled = false;
            numberLabel.IsEnabled = false;
            usernameLabel.IsEnabled = false;
            passwordLabel.IsEnabled = false;

            var user_info = await db.GetUser(username);

            if (user_info != null)
            {
                firstLabel.Text = user_info.First_name;
                nameLabel.Text = user_info.Name;
                lastLabel.Text = user_info.Last_name;
                mailLabel.Text = user_info.Email;
                numberLabel.Text = user_info.Number;
                usernameLabel.Text = user_info.Username;
                passwordLabel.Text = user_info.Password;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //edit
        {
            if (isEdit == false)
            {
                isEdit = true;

                firstLabel.IsEnabled = true;
                nameLabel.IsEnabled = true;
                lastLabel.IsEnabled = true;
                mailLabel.IsEnabled = true;
                numberLabel.IsEnabled = true;
                passwordLabel.IsEnabled = true;
            }
        }

        private async void Button_Click_5(object sender, RoutedEventArgs e) //save
        {
            try
            {
                DB dB = new DB();

                await dB.UpdateUser(username, firstLabel.Text, nameLabel.Text, lastLabel.Text, mailLabel.Text, numberLabel.Text, passwordLabel.Text, "Пользователь");
            }
            catch
            {
                MessageBox.Show("При сохранении произошла ошибка, попробуйте позже!");
            }

            isEdit = false;

            firstLabel.IsEnabled = false;
            nameLabel.IsEnabled = false;
            lastLabel.IsEnabled = false;
            mailLabel.IsEnabled = false;
            numberLabel.IsEnabled = false;
            usernameLabel.IsEnabled = false;
            passwordLabel.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //prev menu
        {
            Menu menu = new Menu(username);
            menu.Show();
            this.Hide();
        }
    }
}
