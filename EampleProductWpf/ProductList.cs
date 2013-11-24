using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Example;

namespace ExampleProductWpf
{
    class ProductList
    {
        public List<Group> Products { get; private set; }

        public ProductList(List<Group> products)
        {
            this.Products = products;
        }

        public ProductList(List<ExampleProductWpf.Product> products)
        {
            var converted = new List<Group>();
            converted.AddRange(products);
            this.Products = converted;
        }

        public ProductList()
        {
            const string ProductGroupName = "Products";
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

            var cheese = new ExampleProductWpf.Product(ProductGroupName, "Cheese", 0.83m);
            var tomato = new ExampleProductWpf.Product(ProductGroupName, "Tomato", 0.53m);
            var beacon = new ExampleProductWpf.Product(ProductGroupName, "Beacon", 1.33m);
            var pizzaWithCheese = new ExampleProductWpf.Product(groups["Pizza"].GroupName, "Cheese pizza", 5.0m, 1,
                new List<ExampleProductWpf.Product>()
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

        public UIElement Render()
        {
            var itemsPanel = new UniformGrid();
            itemsPanel.Rows = 2;

            foreach (var item in Products)
            {
                Button button = (Button)item.Render();
                button.Click += (sender, args) =>
                {
                    var window = new ListWindow();
                    if (item.GetType() == typeof(Group))
                    {
                        window.Container.Children.Add(
                            ProductList.GetByGroup(item.GroupName, Products).Render());
                    }
                    else
                    {
                        var product = item as ExampleProductWpf.Product;
                        window.Container.Children.Add(product.Render());
                        if (product.Recipe != null)
                        {
                            window.Container.Children.Add(new ProductList(product.Recipe).Render());
                        }
                    }
                    window.Show();
                };
                itemsPanel.Children.Add(button);
            }
            return itemsPanel;
        }

        public static ProductList GetByGroup(string group, List<Group> products)
        {
            var result = new List<Group>();
            foreach (var item in products)
            {
                if (item.GroupName.Equals(group))
                {
                    result.Add(item);
                }
            }
            return new ProductList(result);
        }
    }
}
