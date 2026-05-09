using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Konditer.Model;

namespace Konditer
{
    public partial class Personal : Window
    {
        public string username = "";
        public double count = 0;
        public bool isEdit = false;
        public Personal(string Username)
        {
            username = Username;
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e) //load form
        {
            DB db = new DB();
            count = await db.GetCountAllUser();

            isEdit = false;

            firstLabel.IsEnabled = false;
            nameLabel.IsEnabled = false;
            lastLabel.IsEnabled = false;
            mailLabel.IsEnabled = false;
            numberLabel.IsEnabled = false;
            usernameLabel.IsEnabled = false;
            passwordLabel.IsEnabled = false;
            roleLabel.IsEnabled = false;

            for (int i = 1; i <= count; i++)
            {
                var user = await db.GetAllUser(i);

                if (user != null)
                {
                    Button btn = new Button
                    {
                        Content = user.First_name + " " + user.Name + " " + user.Last_name,
                        Margin = new Thickness(0, 5, 0, 5),
                        Width = 390,
                        Height = 40
                    };

                    btn.Click += async (s, e) =>
                    {
                        var user_info = await db.GetUser(user.Username);

                        if (user_info != null)
                        {
                            firstLabel.Text = user_info.First_name;
                            nameLabel.Text = user_info.Name;
                            lastLabel.Text = user_info.Last_name;
                            mailLabel.Text = user_info.Email;
                            numberLabel.Text = user_info.Number;
                            usernameLabel.Text = user_info.Username;
                            passwordLabel.Text = user_info.Password;

                            if (user_info.Role == "Администратор")
                                roleLabel.SelectedIndex = 0;
                            else
                                roleLabel.SelectedIndex = 1;
                        }
                    };

                    listView.Items.Add(btn);
                }
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e) //find number
        {
            string phone = numBox.Text;

            DB dB = new DB();

            if (phone != "")
            {
                try
                {
                    var user = await dB.GetUserFromNumber(phone);

                    if (user != null)
                    {
                        firstLabel.Text = user.First_name;
                        nameLabel.Text = user.Name;
                        lastLabel.Text = user.Last_name;
                        mailLabel.Text = user.Email;
                        numberLabel.Text = user.Number;
                        usernameLabel.Text = user.Username;
                        passwordLabel.Text = user.Password;
                        if (user.Role == "Администратор")
                            roleLabel.SelectedIndex = 0;
                        else
                            roleLabel.SelectedIndex = 1;
                    }
                }
                catch
                {
                    MessageBox.Show("При поиске произошла ошибка, попробуйте позже!");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните поле!");
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e) //find id
        {
            string id = idBox.Text;

            DB dB = new DB();

            if (id != "")
            {
                try
                {
                    var user = await dB.GetUserFromID(id);

                    if (user != null)
                    {
                        firstLabel.Text = user.First_name;
                        nameLabel.Text = user.Name;
                        lastLabel.Text = user.Last_name;
                        mailLabel.Text = user.Email;
                        numberLabel.Text = user.Number;
                        usernameLabel.Text = user.Username;
                        passwordLabel.Text = user.Password;
                        if (user.Role == "Администратор")
                            roleLabel.SelectedIndex = 0;
                        else
                            roleLabel.SelectedIndex = 1;
                    }
                }
                catch
                {
                    MessageBox.Show("При поиске произошла ошибка, попробуйте позже!");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните поле!");
            }
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e) //find mail
        {
            string mail = mailBox.Text;

            DB dB = new DB();

            if (mail != "")
            {
                try
                {
                    var user = await dB.GetUserFromMail(mail);

                    if (user != null)
                    {
                        firstLabel.Text = user.First_name;
                        nameLabel.Text = user.Name;
                        lastLabel.Text = user.Last_name;
                        mailLabel.Text = user.Email;
                        numberLabel.Text = user.Number;
                        usernameLabel.Text = user.Username;
                        passwordLabel.Text = user.Password;
                        if (user.Role == "Администратор")
                            roleLabel.SelectedIndex = 0;
                        else
                            roleLabel.SelectedIndex = 1;
                    }
                }
                catch
                {
                    MessageBox.Show("При поиске произошла ошибка, попробуйте позже!");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните поле!");
            }
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e) //find username
        {
            string login = usernameBox.Text;

            DB dB = new DB();

            if (login != "")
            {
                try
                {
                    var user = await dB.GetUser(login);

                    if (user != null)
                    {
                        firstLabel.Text = user.First_name;
                        nameLabel.Text = user.Name;
                        lastLabel.Text = user.Last_name;
                        mailLabel.Text = user.Email;
                        numberLabel.Text = user.Number;
                        usernameLabel.Text = user.Username;
                        passwordLabel.Text = user.Password;
                        if (user.Role == "Администратор")
                            roleLabel.SelectedIndex = 0;
                        else
                            roleLabel.SelectedIndex = 1;
                    }
                }
                catch
                {
                    MessageBox.Show("При поиске произошла ошибка, попробуйте позже!");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните поле!");
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
                roleLabel.IsEnabled = true;
            }
        }

        private async void Button_Click_5(object sender, RoutedEventArgs e) //save
        {
            try
            {
                DB dB = new DB();

                await dB.UpdateUser(username, firstLabel.Text, nameLabel.Text, lastLabel.Text, mailLabel.Text, numberLabel.Text, passwordLabel.Text, roleLabel.Text);
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
            roleLabel.IsEnabled = false;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e) //prev
        {
            Menu_admin menu = new Menu_admin(username);
            menu.Show();
            this.Hide();
        }
    }
}
