using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StichtitePizzaForm.Products
{
    class ReadProducts
    {
        public static CheckableObservableCollection<string> ReadMenuList()
        {
            CheckableObservableCollection<string> items = new CheckableObservableCollection<string>();
            using (StreamReader reader = new StreamReader("PizzaMenu.csv"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    items.Add(line.Replace(',', ' '));
                    line = reader.ReadLine();
                }
            }
            return items;
        }
    }
}