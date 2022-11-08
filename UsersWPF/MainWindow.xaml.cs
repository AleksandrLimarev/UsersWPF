﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
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

namespace UsersWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;

        
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "This field is incorrect, you should have at least 5 letters";
                textBoxLogin.Background = Brushes.DarkRed;


            } else if (pass.Length < 5)
            {
                passBox.ToolTip = "This field is incorrect, you should have at least 5 letters";
                textBoxLogin.Background = Brushes.DarkRed;
            } else if (pass != pass_2)
            {
                passBox_2.ToolTip = "Password doesn't match";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains('@'))
            {
                passBox_2.ToolTip = "This field is incorrect";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("You Logged in!");

                User user = new User(login, email, pass);
                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Hide();

            }


        }

        private void Button_Window_Auth_CLick(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }
    }
}
