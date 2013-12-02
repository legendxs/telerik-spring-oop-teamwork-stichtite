using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Collections;

namespace StichtitePizzaForm.Products
{
    public class ProductList : INotifyPropertyChanged
    {
        private CheckableObservableCollection<string> items;

        public event PropertyChangedEventHandler PropertyChanged;

        public ProductList()
        {
            Items = ReadProducts.ReadMenuList();
        }

        public CheckableObservableCollection<string> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
                OnPropertyChanged("Items");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler pceh = PropertyChanged;
            if (pceh != null)
            {
                pceh(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}