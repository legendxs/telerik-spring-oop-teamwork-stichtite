using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StichtitePizzaForm.Products
{
    public class CheckWrapper<T> :  INotifyPropertyChanged
    {
        private readonly CheckableObservableCollection<T> parent;
        private T value;
        private bool isChecked;

        public event PropertyChangedEventHandler PropertyChanged;

        public CheckWrapper(CheckableObservableCollection<T> parent)
        {
            this.parent = parent;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        public bool IsChecked
        {
            get
            {
                return this.isChecked;
            }
            set
            {
                this.isChecked = value;
                CheckChanged();
                OnPropertyChanged("IsChecked");
            }
        }

        private void CheckChanged()
        {
            parent.Refresh();
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
