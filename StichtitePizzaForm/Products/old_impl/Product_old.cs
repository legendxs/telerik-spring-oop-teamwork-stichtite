using System;
using System.Linq;
using StichtitePizzaForm.Products.old_impl.Interfaces;

namespace StichtitePizzaForm.Products.old_impl
{
    abstract  class Product_old : IProduct
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
