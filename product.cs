using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWRY
{
    public class Product
    {
        public string Name { get; }
        public double Price { get; }
        public int Quantity { get; private set; }
        public DateTime? ExpiryDate { get; }

        public Product(string name, double price, int quantity, DateTime? expiryDate = null)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            ExpiryDate = expiryDate;
        }

        public bool IsExpired() => ExpiryDate.HasValue && DateTime.Now > ExpiryDate.Value;

        public void ReduceStock(int amount)
        {
            if (amount > Quantity)
                throw new InvalidOperationException($"{Name} has insufficient stock.");
            Quantity -= amount;
        }

        public override string ToString() => $"{Name} - ${Price} x {Quantity}";
    }

}
