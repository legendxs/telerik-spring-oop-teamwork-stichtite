using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StichtitePizzaForm
{
    public partial class ClientWindowStart : Window
    {
        public ObservableCollection<Wrapper<MyCustomer>> Customers { get; set; }

        public ClientWindowStart()
        {
            InitializeComponent();

            Customers = new ObservableCollection<Wrapper<MyCustomer>>();

            using (StreamReader reader = new StreamReader("PizzaMenu.csv"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Customers.Add(new Wrapper<MyCustomer>(new MyCustomer() { Name = line.Replace(',', ' ').Trim() }));
                    line = reader.ReadLine();
                }
            }
            
            DataContext = this;
        }

        private void HandleChecker(object sender, RoutedEventArgs e)
        {
            foreach (var item in Customers)
            {
                if (item.IsChecked && !item.IsAdded)
                {
                    TextBlock printTextBlock = new TextBlock();
                    printTextBlock.Text = item.ItemName;
                    pannel.Children.Add(printTextBlock);
                    item.IsAdded = true;
                }
            }
        }

        private void EmptyBasket(object sender, RoutedEventArgs e)
        {
            this.pannel.Children.Clear();
            foreach (var item in Customers)
            {
                if (item.IsChecked && item.IsAdded)
                {
                    item.IsAdded = false;
                    item.IsChecked = false;
                }
            }
        }

        private void SendOrder(object sender, RoutedEventArgs e)
        {
            StringBuilder result = new StringBuilder();
            if (result.Length != 0)
            {
                foreach (var item in Customers)
                {
                    if (item.IsAdded)
                    {
                        result.AppendLine(item.ItemName.Replace(' ', ','));
                    }
                }
                using (StreamWriter writer = new StreamWriter("OrderList.csv", true))
                {
                    writer.Write(result.ToString());
                }
                MessageBox.Show("Order sended!");
            }
            else
            {
                MessageBox.Show("Empty basket!");
            }
        }
    }
}