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
               connection.Execute($"INSERT INTO dbo.Product (ProductID, Productname, Productclass, Productquanity) VALUES ({productID}, '{productName}', '{productClass}', {productQuanity})");
            }
            else
            {
                Console.WriteLine("Failed Connection");
                throw new Exception();
            }

        }

        public void RemoveProduct(int productID)
        {
            using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("connectDB"));
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
               connection.Execute($"DELETE FROM  dbo.Product WHERE ProductID = {productID}");
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
               connection.Execute($"SELECT * from dbo.Employee WHERE LastName ={Lastname}");
            }
            else
            {
                Console.WriteLine("Failed Connection");
                throw new Exception();
            }
        }

    }
}