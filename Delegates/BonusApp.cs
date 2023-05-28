using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    

    public delegate double BonusProvider(double amount);
    public class Bonuses
    {
        public static double TenPercent(double amount)
        {
            return amount * 0.10;
        }

        public static double FlatTwoIfAmountMoreThanFive(double amount) 
        {
            double returnValue;
            if (amount > 5) {
                returnValue = 2.0;
            }
            else {
                returnValue = 0.0;
            }
            return returnValue;
        }
    }
    

    public class Order
    {
        public BonusProvider Bonus { get; set; }
        public List<Product> products { get; set; }

        // Hver gang man laver en order, tilføjer man produkter til listen tilknyttet til den ordre
        public Order()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product p) 
        {
            products.Add(p);
        }

        public double GetValueOfProducts()
        {
            double totalValue = 0;
            foreach (Product p in products) {
                totalValue += p.Value;
            }
            return totalValue;
        }

        public double GetBonus()
        {
            // Returnerer en bonus fra den samlede værdi af alle produkter
            // Hvilken delegate der bliver kaldt, bliver bestemt når man kalder metoden udefra
            return Bonus(GetValueOfProducts());
        }

        public double GetTotalPrice()
        {
            // Returnerer en samlet værdi er produkter minus den beregnede bonus
            return GetValueOfProducts() - GetBonus();
        }

    }

        public class Product
        {
            public string Name { get; set; }
            public double Value { get; set; }
        }
}
