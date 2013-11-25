using System;
using System.Collections.Generic;
using System.Linq;

namespace StichtitePizzaForm.Products
{
    /// <summary>
    /// Contains all products available. Creates a product object link with the UI
    /// </summary>
    public class ProductList
    {
        public List<Group> Products { get; private set; }

        public ProductList(List<Group> products)
        {
            this.Products = products;
        }

        public ProductList(List<Product> products)
        {
            var converted = new List<Group>();
            converted.AddRange(products);
            this.Products = converted;
        }

        public ProductList()
        {
            const string ProductGroupName = "Products";

            //Create some groups
            var groupNames = new string[] {
                "Pizza",
                "Soft drinks",
                "Beer",
                "Sandwiches",
                ProductGroupName
            };

            var groups = new Dictionary<string, Group>();
            foreach (var item in groupNames)
            {
                groups.Add(item, new Group(item));
            }

            //add some products
            var cheese = new Product(ProductGroupName, "Cheese", 0.83m);
            var tomato = new Product(ProductGroupName, "Tomato", 0.53m);
            var beacon = new Product(ProductGroupName, "Beacon", 1.33m);

            //create pizza
            var pizzaWithCheese = new Product(groups["Pizza"].GroupName, "Cheese pizza", 5.0m, 1,
                new List<Product>()
                {
                    cheese,
                    tomato,
                    beacon
                });
            Products = new List<Group>()
            {
                cheese, tomato,beacon, pizzaWithCheese
            };
        }

        //TODO render the product list
        //public UIElement Render()
        //{
        //    var itemsPanel = new UniformGrid();
        //    itemsPanel.Rows = 2;

        //    foreach (var item in Products)
        //    {
        //        Button button = (Button)item.Render();
        //        button.Click += (sender, args) =>
        //        {
        //            var window = new ListWindow();
        //            if (item.GetType() == typeof(Group))
        //            {
        //                window.Container.Children.Add(
        //                    Group.GetAllByGroup(item.GroupName, Products).Render());
        //            }
        //            else
        //            {
        //                var product = item as Product;
        //                window.Container.Children.Add(product.Render());
        //                if (product.Recipe != null)
        //                {
        //                    window.Container.Children.Add(new ProductList(product.Recipe).Render());
        //                }
        //            }
        //            window.Show();
        //        };
        //        itemsPanel.Children.Add(button);
        //    }
        //    return itemsPanel;
        //}

    }
}
