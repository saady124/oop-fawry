using System;
using System.Collections.Generic;
using System.Linq;
using FAWRY;

namespace FAWRY
{
    public class main
    {
        public static void Main()
        {
            var cheese = new Product("Cheese", 50, 10, DateTime.Now.AddDays(2));
            var tv = new Product("TV", 250, 3);
            var scratchCard = new Product("Scratch Card", 10, 20);
            var customer = new Customer("elsa3dy", 1000);
            try
            {
                customer.AddToCart(cheese, 2);
                customer.AddToCart(tv, 2);
                customer.AddToCart(scratchCard, 3);
                customer.Checkout();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Checkout failed: " + ex.Message);
            }
        }
    }
}
