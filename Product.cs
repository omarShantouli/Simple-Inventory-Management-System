using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Management_System
{
    internal class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public Product(string name, decimal price, int quantity)
        {
            Name= name;
            Price= price;   
            QuantityInStock= quantity;
        }
    }
}
