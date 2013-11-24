using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StichtitePizzaForm
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
