using System;
using System.Collections.Generic;

namespace Simple_Inventory_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product("Smart TV", 1500, 100),
                new Product("Air Conditioner", 3200, 270),
                new Product("Electric Blender", 150, 180),
                new Product("Fan", 180, 310)
            };

            UserInterface userInterface= new UserInterface();
            foreach(Product product in products)
            {
                userInterface.AddProduct(product);
            }

            userInterface.ListProducts();

        }
    }
}
