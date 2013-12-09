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
    public class ObserveItems<T> : ObservableCollection<Wrapper<T>>
    {
        private readonly ListCollectionView selectedItems;

        public ObserveItems()
        {
            selectedItems = new ListCollectionView(this);
            selectedItems.Filter = delegate(object checkObject)
            {
                return ((Wrapper<T>)checkObject).IsChecked;
            };
        }

        public void Add(T item)
        {
            this.Add(new Wrapper<T>(this) { Value = item });
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