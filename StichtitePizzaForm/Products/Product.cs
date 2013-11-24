using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StichtitePizzaForm
{
    abstract public class Product : IProduct
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Calories { get; set; }
        
        public virtual void CalculatePrice()
        {
            throw new NotImplementedException();
            // must be initiated as soon as a product is added for the pizzas
        }
    }
}
