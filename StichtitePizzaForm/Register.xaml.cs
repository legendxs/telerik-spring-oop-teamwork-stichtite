using System;
using System.Linq;
using System.Windows;

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
