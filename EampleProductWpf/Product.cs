using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ExampleProductWpf
{
    class Product : Group
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }
        public List<Product> Recipe { get; private set; }

        public Product(string group, string name, decimal price = 0.0m, double quantuty = 1.0, List<Product> recipe = null)
            : base(group)
        {
            this.Name = name;
            this.Quantity = quantuty;
            this.Price = price;
            this.Recipe = recipe;
            var picture =
                (Image)Application.Current.FindResource("ProductImage");
            if (recipe != null)
            {
                picture = (Image)Application.Current.FindResource("GroupImage");
            }
            this.Picture = CloneImage(picture);
        }

        public override object Clone()
        {
            Group clonedGroup = base.Clone() as Group;

            List<Product> clonedRecipe = null;
            if (Recipe != null)
            {
                clonedRecipe = new List<Product>();
                foreach (var product in Recipe)
                {
                    clonedRecipe.Add((Product)product.Clone());
                }
            }

            var clonedProduct = new Product(clonedGroup.GroupName, this.Name, this.Price, this.Quantity, clonedRecipe);
            clonedProduct.Picture = clonedGroup.Picture;
            return clonedProduct;
        }

        public override UIElement Render()
        {
            return CreateImageButton(CloneImage(this.Picture), this.Name);
        }
    }
}
