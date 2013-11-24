using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StichtitePizzaForm
{
    public interface IPizza
    {
        SauceType Sauce { get; set; }
        List<ToppingType> Ingredients { get; set; }
        void AddTopping(ToppingType topping);
        void RemoveTopping(ToppingType topping);
    }
}
