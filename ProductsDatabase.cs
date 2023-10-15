using Simple_Inventory_Management_System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simple_Inventory_Management_System
{
    public static class ProductsDatabase
    {
        public static void AddProductToDatabase(Product product)
        {

            string connectionString = "Server=OMAR\\SQLEXPRESS;Database=Simple Inventory Management System Database;Trusted_Connection=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO product (ProductName, Price, Quantity) VALUES (@Name, @Price, @Quantity)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Quantity", product.QuantityInStock);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Inserted {rowsAffected} row(s) for {product.Name}");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting to the database: " + ex.Message);
            }
        }
        
        public static List<Product> GetAllProductsFromDatabase()
        {
            string selectQuery = "SELECT * FROM Product";
            string connectionString = "Server=OMAR\\SQLEXPRESS;Database=Simple Inventory Management System Database;Trusted_Connection=True;";
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int productId = reader.GetInt32(reader.GetOrdinal("ProductID"));
                        string productName = reader.GetString(reader.GetOrdinal("ProductName"));
                        decimal price = reader.GetDecimal(reader.GetOrdinal("Price"));
                        int quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));

                        products.Add(new Product(productName, price, quantity));
                    }
                }
            }
            return products;
        }
        
        public static void DeleteProduct(string name)
        {
            string connectionString = "Server=OMAR\\SQLEXPRESS;Database=Simple Inventory Management System Database;Trusted_Connection=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "DELETE FROM Product WHERE ProductName = @Name";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Deleted {rowsAffected} row(s) for {name}");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting to the database: " + ex.Message);
            }
        }
        
        public static void UpdateProduct(string oldProductName, Product newProduct)
        {
            string connectionString = "Server=OMAR\\SQLEXPRESS;Database=Simple Inventory Management System Database;Trusted_Connection=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "update Product set ProductName =@newName" +
                                                            ", Price = @newPrice," +
                                                            " Quantity = @newQuantity " +
                                                            "where ProductName = @Name;";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", oldProductName);
                        command.Parameters.AddWithValue("@newName", newProduct.Name);
                        command.Parameters.AddWithValue("@newPrice", newProduct.Price);
                        command.Parameters.AddWithValue("@newQuantity", newProduct.QuantityInStock);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Deleted {rowsAffected} row(s) for {oldProductName}");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting to the database: " + ex.Message);
            }
        }
    }
}

