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
            if (string.IsNullOrWhiteSpace(username.Text.ToString())) 
            {
                MessageBox.Show("Please enter name!");
            }
            else if (string.IsNullOrWhiteSpace(password.Text.ToString()))
            {
                MessageBox.Show("Please enter password!");
            }
            else if (string.IsNullOrWhiteSpace(address.Text.ToString()))
            {
                MessageBox.Show("Please enter address!");
            }
            else if (string.IsNullOrWhiteSpace(phone.Text.ToString()))
            {
                MessageBox.Show("Please enter phone number!");
            }
            else
            {
                User.CreateAcc(username.Text.ToString(), password.Text.ToString(), AccountType.Client, address.Text.ToString(), phone.Text.ToString());
                (new MainWindow()).Show();
                this.Close();
            }
        }
    }
}