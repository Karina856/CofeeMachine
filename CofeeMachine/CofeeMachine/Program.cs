using System;
using System.Collections.Generic;

namespace CofeeMachine 
{
    public class Program
    {
        static void Main(string[] args)
        {
            CofeeMach machine = new CofeeMach(new Dictionary<string, decimal> { { "Black cofee", 0.80m }, { "Latte", 1.00m } });
            Console.WriteLine(machine.PrintProductListWithPrice());
            machine.AddCoin(0.50m);
            machine.AddCoin(0.20m);
            machine.AddCoin(0.3m);
            machine.AddCoin(0.20m);
            machine.CoinsAmount();
            machine.selectedDrink = "Black cofee";
            machine.MakeDrink();

        }
    }
}