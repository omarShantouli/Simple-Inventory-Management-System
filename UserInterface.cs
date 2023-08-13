using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Management_System
{
    internal class UserInterface
    {
        private Inventory inventory = new Inventory();

        public void AddProduct(Product product) 
        {
            inventory.AddProduct(product); 
        }
        public void ListProducts()
        {
            foreach (var product in inventory.GetProducts())
            {
                Console.WriteLine($"{product.Name}  {product.Price}  {product.QuantityInStock}");
            }
        }



    }
}
