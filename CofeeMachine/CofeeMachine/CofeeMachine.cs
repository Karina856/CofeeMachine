using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeMachine
{
    public class CofeeMach
    {
        public Dictionary<string, decimal> _productWithPrice;
        public CofeeMach()
        {
            _productWithPrice = new Dictionary<string, decimal>();
        }

        public CofeeMach(Dictionary<string, decimal> productWithPrice)
        {
            _productWithPrice = productWithPrice;
        }

        public string PrintProductListWithPrice()
        {
            string listOfProducts = "";
            foreach(var item in _productWithPrice)
                listOfProducts += item.Key + " " + item.Value + " ";
            return listOfProducts;
        }

        public decimal insertedCoinsAmount = 0;

        public List<decimal> allowedCoins = new List<decimal> { 0.01m, 0.02m, 0.05m, 0.10m, 0.20m, 0.50m, 1.00m, 2.00m };
        public decimal AddCoin(decimal coin)
        {
            if (allowedCoins.Contains(coin))
            {
                insertedCoinsAmount += coin;
            }
            else
            {
                Console.WriteLine("Incorrect coin");
            }
            return insertedCoinsAmount;
        }

        public void CoinsAmount()
        {
            Console.WriteLine("Coins amount: " + insertedCoinsAmount);
        }

        public string selectedDrink { get; set; }

        

        public string MakeDrink()
        {
            string result = "";
            if (_productWithPrice.ContainsKey(selectedDrink)==true && insertedCoinsAmount>=_productWithPrice.GetValueOrDefault(selectedDrink))
            {
                decimal change = insertedCoinsAmount - _productWithPrice.GetValueOrDefault(selectedDrink);
             
                result = "Drink " + selectedDrink + " is made, your change is " + change;
            }
            else if (_productWithPrice.ContainsKey(selectedDrink) == false)
            {
                result = "Ordered incorrect drink";
            }
            else if (insertedCoinsAmount < _productWithPrice.GetValueOrDefault(selectedDrink))
            {
                result = "Inserted coins are not enough";
            }
            else {
                result = "There is a problem in  a system or order";
            }
            return result;
        }
    }
}
