namespace StichtitePizzaForm
{
    using System.Collections.Generic;
    using StichtitePizzaForm.Products;
    using System.Text;

    public class Order
    {
        public int OrderNumber { get; set; }

        public decimal Price { get; set; }

        public List<Product> Products { get; set; }

        public void AddProductToList(Product product)
        {
            this.Products.Add(product);
        }

        public void RemoveProductFromList(Product product)
        {
            this.Products.Remove(product);
        }

        public void ClearList()
        {
            this.Products.Clear();
        }

        public decimal CalculateTotalPrice()
        {
            var total = 0m;

            foreach (var product in this.Products)
            {
                total += product.Price;
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Order {0}:\n", this.OrderNumber));
            foreach (var product in this.Products)
            {
                result.Append(product.ToString() + "\n");
                result.Append("---------------");
            }
            return base.ToString();
        }
    }
}