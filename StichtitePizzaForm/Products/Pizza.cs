using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StichtitePizzaForm
{
    public class Pizza : Product, IPizza
    {
        public const double Dough = 1;
        public SauceType Sauce { get; set; }
        // Will be entering the prices of the ingredients with (double)ToppingType like value
        public List<ToppingType> Ingredients = new List<ToppingType>();

        public void AddTopping(ToppingType topping)
        {
            Ingredients.Add(topping);
            CalculatePrice();
        }

        public void RemoveTopping(ToppingType topping)
        {
            Ingredients.Remove(topping);
            CalculatePrice();
        }

        public override void CalculatePrice()
        {
            double newPrice = 1;
            newPrice += (double)this.Sauce;
            foreach (var topping in Ingredients)
            {
                newPrice += (double)topping;
            }
            this.Price = newPrice;
        }

        // for representation of the product in the UI
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(String.Format("Pizza : {0} ----- Price : {1}\n", this.Name, this.Price));
            result.Append(String.Format("Sauce : {0}\n", this.Sauce));
            if (Ingredients.Count > 0)
            {
                result.Append("Toppings : ");
                foreach (var topping in Ingredients)
                {
                    result.Append(topping + " - " + (double)topping + ",");
                }
                result.Length -= 1;
                result.Append(";");
            }
            return result.ToString();
        }
    }
}
