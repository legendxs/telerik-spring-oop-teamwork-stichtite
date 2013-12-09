using System.ComponentModel;

namespace StichtitePizzaForm
{
    public class Wrapper<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isChecked;
        private MyCustomer item;
        private bool isAdded;

        public Wrapper()
        { }

        public Wrapper(MyCustomer item, bool isChecked = false)
        {
            this.item = item;
            this.isChecked = isChecked;
        }

        public MyCustomer Item
        {
            get { return item; }
            set
            {
                item = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Item"));
            }
        }

        public string ItemName
        {
            get
            {
                return this.item.Name;
            }
        }

        public bool IsAdded
        {
            get
            {
                return this.isAdded;
            }
            set
            {
                this.isAdded=value;
            }
        }

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }
    }
}