using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StichtitePizzaForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLogInClick(object sender, RoutedEventArgs e)
        {
            User.LogIn(Username.Text.ToString(), Password.Password.ToString());
        }

        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            Window registerWindow = new Register();
            registerWindow.Show();
            this.Close();
        }

        private void OnUsernameLoaded(object sender, RoutedEventArgs e)
        {
            TextBox loginBox = sender as TextBox;
            loginBox.Focus();
        }

    }
}
