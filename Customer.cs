using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAWRY;

namespace FAWRY
{
    public class Customer
    {
        public string Name { get; }
        public double Balance { get; private set; }
        private List<CartItem> Cart = new();

        public Customer(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }

        public void AddToCart(Product product, int quantity)
        {
            if (quantity <= 0 || quantity > product.Quantity)
                throw new InvalidOperationException("Invalid quantity.");
            Cart.Add(new CartItem(product, quantity));
        }

        public void Checkout()
        {
            if (!Cart.Any())
                throw new InvalidOperationException("Cart is empty.");

            double subtotal = 0;

            Console.WriteLine("\n=== Cart Summary ===");
            foreach (var item in Cart)
            {
                if (item.Product.IsExpired())
                    throw new InvalidOperationException($"{item.Product.Name} is expired.");
                if (item.Quantity > item.Product.Quantity)
                    throw new InvalidOperationException($"{item.Product.Name} is out of stock.");

                double itemTotal = item.Total;
                subtotal += itemTotal;

                Console.WriteLine($"Product: {item.Product.Name} | Price: ${item.Product.Price} | Quantity: {item.Quantity} | Total: ${itemTotal}");
            }

            if (subtotal > Balance)
                throw new InvalidOperationException("Insufficient balance.");

            foreach (var item in Cart)
                item.Product.ReduceStock(item.Quantity);

            Balance -= subtotal;

            Console.WriteLine("\n=== Checkout Successful ===");
            Console.WriteLine($"Subtotal: ${subtotal}");
            Console.WriteLine($"Total Paid: ${subtotal}");
            Console.WriteLine($"Remaining Balance: ${Balance}");
        }
    }
}
