﻿using System;
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

namespace StichtitePizzaForm
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        public void OnRegsterClick(object sender, RoutedEventArgs e)
        {
            User.CreateAcc(username.Text.ToString(), password.Text.ToString(), AccountType.Client, adress.Text.ToString(), phone.Text.ToString());
        }
    }
}