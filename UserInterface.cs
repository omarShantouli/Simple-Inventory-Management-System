using System;
using System.Collections.Generic;
using System.Linq;

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

                    ProductsDatabase.UpdateProduct(productName, product);
                    Console.WriteLine("Edited successfully");
                    return;

                }
            }
            Console.WriteLine("Your product is not exist!");

        }

        public void DeleteProduct(string productName)
        {
            List<Product> products = inventory.GetProducts();
            for (int i = 0; i < products.Count; i++)
            {
                //Console.WriteLine(products[i].Name.ToLower().Equals(productName.ToLower()));
                if (products[i].Name.ToLower() == productName.ToLower())
                {
                    Console.WriteLine($"The product you want to delete is :" +
                        $" {products[i].Name} {products[i].Price} {products[i].QuantityInStock}");
                    string ok;
                    while (true)
                    {
                        Console.WriteLine("Are you sure to delete this product? (y/n)");
                        ok = Console.ReadLine();
                        if(ok == "y")
                        {
                            inventory.products.RemoveAt(i);
                            ProductsDatabase.DeleteProduct(productName);
                            Console.WriteLine("Product is deleted successfully!");
                            return;
                        }
                        else if(ok == "n")
                        {
                            Console.WriteLine("Product is not deleted!");
                            return;
                        }

                    }
                }
            }
            
            Console.WriteLine("Your product is not exist");

        }


    }
}
