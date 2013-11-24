namespace StichtitePizzaForm
{
    using System.Collections.Generic;

    public class Order
    {
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

        public double CalculateTotalPrice()
        {
            double total = 0;

            foreach (var product in this.Products)
            {
                total += product.Price;
            }

            return total;
        }
    }
}