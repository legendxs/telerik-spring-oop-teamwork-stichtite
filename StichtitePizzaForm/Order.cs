namespace StichtitePizzaForm
{
    using System.Collections.Generic;
    using StichtitePizzaForm.Products;

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

        public decimal CalculateTotalPrice()
        {
            var total = 0m;

            foreach (var product in this.Products)
            {
                total += product.Price;
            }

            return total;
        }
    }
}