using System;
using System.Linq;

namespace StichtitePizzaForm.Products.old_impl.Interfaces
{
    interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        // eventualy calculated and adding callories calculations
        int Calories { get; set; }
        void CalculatePrice();
    }
}
