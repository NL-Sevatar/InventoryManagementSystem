using Dapper;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
 

namespace InventoryManagement
{

    public static class Helper
    {
        public static string CnnVal(string name) 
        {
            string connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine($"Connection string '{name}' not found or is empty.");
                throw new Exception("Connection not found or is empty.");
            }
            else
            {
                return connectionString;
            }
            
        }
    }
    public class DataAccess
    {
        public List<Product> GetProduct(string ProductName)
        {
           using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("connectDB"));
           connection.Open();
           
            if (connection.State == ConnectionState.Open)
            {
                return connection.Query<Product>($"select * from Product where ProductName = '{ProductName}'").ToList();
            }
            else
            {
                Console.WriteLine("Failed Connection");
                throw new Exception();
            }
        }

        public void AddProduct(int productID, string productName, string productClass, int productQuanity )
        {
            using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("connectDB"));
           connection.Open();
           
            if (connection.State == ConnectionState.Open)
            {
               connection.Execute($"INSERT INTO dbo.Product (product_id, product_name, product_class, product_quanity) VALUES ({productID}, '{productName}', '{productClass}', {productQuanity})");
            }
            else
            {
                Console.WriteLine("Failed Connection");
                throw new Exception();
            }

        }

        public void RemoveProduct(int product_id)
        {
            using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("connectDB"));
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
               connection.Execute($"DELETE FROM  dbo.Product WHERE ProductID = {product_id}");
            }
            else
            {
                Console.WriteLine("Failed Connection");
                throw new Exception();
            }
        }

        public void EmployeeSearch (string Lastname)
        {
            using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("connectDB"));
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
               connection.Execute($"SELECT * from dbo.Employee WHERE last_name ={Lastname}");
            }
            else
            {
                Console.WriteLine("Failed Connection");
                throw new Exception();
            }
        }
         internal void NewUser(string user_id, string username, string HashPassword, string role)
         {
            using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("connectDB"));
           connection.Open();
           
            if (connection.State == ConnectionState.Open)
            {
                connection.Execute($"INSERT INTO dbo.User () ");
                
            }
            else
            {
                Console.WriteLine("Failed Connection");
                throw new Exception();
            }
         }

    }
}