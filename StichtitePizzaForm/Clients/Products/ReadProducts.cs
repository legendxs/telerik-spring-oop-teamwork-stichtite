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
        public static ObserveItems<string> ReadMenuList()
        {
            ObserveItems<string> items = new ObserveItems<string>();
            using (StreamReader reader = new StreamReader("PizzaMenu.csv"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    items.Add(line.Replace(',', ' ').Trim());
                    line = reader.ReadLine();
                }
            }
            return items;
        }
    }
}