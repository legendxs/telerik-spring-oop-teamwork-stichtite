using System;
using System.Collections.Generic;
using System.Linq;

namespace Products
{
    class Product : Group
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Product> Recipe { get; private set; }

        public Product(string group, string name, decimal price = 0.0m, List<Product> recipe=null)
            : base(group)
        {
            this.Name = name;
            this.Price = price;
            this.Recipe = recipe;
        }

        public override object Clone()
        {
            List<Product> clonedRecipe = null;
            if (Recipe != null)
            {
                clonedRecipe = new List<Product>();
                foreach (var product in Recipe)
                {
                    clonedRecipe.Add((Product)product.Clone());
                }
            }
            return new Product(this.GroupName, this.Name, this.Price, clonedRecipe);
        }
    }
}
