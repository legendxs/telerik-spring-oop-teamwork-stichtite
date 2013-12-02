using System;
using System.Linq;
using StichtitePizzaForm.Products.old_impl.TypesEnums;

namespace StichtitePizzaForm.Products.old_impl.Interfaces
{
    public interface IPizza
    {
        SauceType Sauce { get; set; }
        //List<ToppingType> Ingredients { get; set; }
        void AddTopping(ToppingType topping);
        void RemoveTopping(ToppingType topping);
    }
}
