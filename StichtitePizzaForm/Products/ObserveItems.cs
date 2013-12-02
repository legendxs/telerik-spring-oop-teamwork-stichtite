using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StichtitePizzaForm.Products
{
    public class CheckableObservableCollection<T> : ObservableCollection<CheckWrapper<T>>
    {
        private ListCollectionView selectedItems;

        public CheckableObservableCollection()
        {
            selectedItems = new ListCollectionView(this);
            selectedItems.Filter = delegate(object checkObject)
            {
                return ((CheckWrapper<T>)checkObject).IsChecked;
            };
        }

        public void Add(T item)
        {
            this.Add(new CheckWrapper<T>(this) { Value = item });
        }

        public ICollectionView CheckedItems
        {
            get
            {
                return selectedItems;
            }
        }

        internal void Refresh()
        {
            selectedItems.Refresh();
        }
    }
}
