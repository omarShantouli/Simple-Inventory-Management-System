using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace Simple_Inventory_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = ProductsDatabase.GetAllProductsFromDatabase();
            Console.WriteLine(products.Count);
            UserInterface userInterface= new UserInterface();
            foreach(Product product in products)
            {
                userInterface.AddProduct(product);
            }

            int choice;

            while (true)
            { 
                Console.WriteLine("Simple Inventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Delete Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. List Products");
                Console.WriteLine("5. Exit");

                choice = Convert.ToInt32(Console.ReadLine());

                if(choice == 1) 
                {
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter product price: ");
                    decimal price = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Enter product quantity in stock: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    Product product = new Product(name, price, quantity);
                    userInterface.AddProduct(product);
                    ProductsDatabase.AddProductToDatabase(product);
                }

                else if(choice == 2) 
                {
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    userInterface.DeleteProduct(name);

                }

                else if(choice == 3) 
                {
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    userInterface.EditProduct(name);
      
                }

                else if (choice == 4) 
                {
                    userInterface.ListProducts();
                }

                else
                {
                    break;
                }
                Console.WriteLine();
            }
        }
        
        
    }
}
