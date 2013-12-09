using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;

namespace StichtitePizzaForm
{
    public partial class ClientWindowStart : Window
    {
        public ObservableCollection<Wrapper<MyCustomer>> Customers { get; set; }

        List<TextBlock> selectedItems = new List<TextBlock>();

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
                    selectedItems.Add(printTextBlock);
                    item.IsAdded = true;
                }
            }
        }

        private void HandleUnChecker(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < selectedItems.Count; i++)
            {
                if ((sender as CheckBox).Content.ToString() == selectedItems[i].Text)
                {
                    pannel.Children.Remove(selectedItems[i]);
                    foreach (var item in Customers)
                    {
                        if (item.ItemName == selectedItems[i].Text)
                        {
                            item.IsAdded = false;
                            item.IsChecked = false;
                            selectedItems.Remove(selectedItems[i]);
                            break;
                        }
                    }
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
        
            foreach (var item in Customers)
            {
                if (item.IsAdded)
                {
                    result.AppendLine(item.ItemName.Replace(' ', ','));
                }
            }
            if (result.Length != 0)
            {
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