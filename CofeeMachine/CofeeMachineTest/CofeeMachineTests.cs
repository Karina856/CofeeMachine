using CofeeMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace CofeeMachineTest
{
    [TestClass]
    public class CofeeMachineTests
    {
        [TestMethod]
        public void PrintProductListWithPrice_ExistOneProduct_BlackCofee()
        {
            CofeeMach machine = new CofeeMach(new Dictionary<string, decimal> { {  "Black cofee", 0.80m }});
            string result = machine.PrintProductListWithPrice();
            string expectedResult = "Black cofee 0.80 ";
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void PrintProductListWithPrice_ExistNoProduct_()
        {
            CofeeMach machine = new CofeeMach(new Dictionary<string, decimal> {});
            string result = machine.PrintProductListWithPrice();
            string expectedResult = "";
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AddCoin_AddedCorrectCoin_1()
        {
            CofeeMach machine = new CofeeMach(new Dictionary<string, decimal> { });
            decimal result = machine.AddCoin(1m);
            decimal expectedResult = 1m;
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AddCoin_AddedIncorrectCoin_0()
        {
            CofeeMach machine = new CofeeMach(new Dictionary<string, decimal> { });
            decimal result = machine.AddCoin(0.3m);
            decimal expectedResult = 0m;
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void MakeDrink_CorrectDrinkAndMoreMoney_0_2()
        {
            CofeeMach machine = new CofeeMach(new Dictionary<string, decimal> { { "Black cofee", 0.80m }, { "Latte", 1.00m } });
            machine.AddCoin(1m);
            machine.selectedDrink = "Black cofee";
            string result = machine.MakeDrink();
            string expectedResult = "Drink Black cofee is made, your change is 0.20";
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void MakeDrink_CorrectDrinkAndEnoughMoney_0()
        {
            CofeeMach machine = new CofeeMach(new Dictionary<string, decimal> { { "Black cofee", 0.80m }, { "Latte", 1.00m } });
            machine.AddCoin(1m);
            machine.selectedDrink = "Latte";
            string result = machine.MakeDrink();
            string expectedResult = "Drink Latte is made, your change is 0.00";
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void MakeDrink_InCorrectDrinkNEnoughMoney_Ordered_incorrect_drink()
        {
            CofeeMach machine = new CofeeMach(new Dictionary<string, decimal> { { "Black cofee", 0.80m }, { "Latte", 1.00m } });
            machine.AddCoin(1m);
            machine.selectedDrink = "Cappuccino";
            string result = machine.MakeDrink();
            string expectedResult = "Ordered incorrect drink";
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void MakeDrink_CorrectDrinkNotEnoughMoney_0()
        {
            CofeeMach machine = new CofeeMach(new Dictionary<string, decimal> { { "Black cofee", 0.80m }, { "Latte", 1.00m } });
            machine.AddCoin(0.2m);
            machine.selectedDrink = "Latte";
            string result = machine.MakeDrink();
            string expectedResult = "Inserted coins are not enough";
            Assert.AreEqual(expectedResult, result);
        }

        
    }
}