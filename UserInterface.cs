using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public void EditProduct(string productName)
        {
            foreach(var product in inventory.GetProducts())
            {
                if(product.Name.ToLower() == productName.ToLower())
                {
                    Console.WriteLine($"The product u want to edit is :" +
                        $" {product.Name} {product.Price} {product.QuantityInStock}");
                    
                    Console.WriteLine("Enter a new name:");
                    product.Name = Console.ReadLine();

                    Console.WriteLine("Enter a new price:");
                    product.Price = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Enter a new quantity in stock:");
                    product.QuantityInStock = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Edited successfully");
                    return;

                }
            }
            Console.WriteLine("Your product is not exist");

        }


    }
}
