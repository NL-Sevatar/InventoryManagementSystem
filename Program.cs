using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Reflection;
using Dapper;
using System.Globalization;

namespace InventoryManagement
{
    class Program
    {   
        public static void Main()
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            bool runningProgram = true;

            while(runningProgram)
            {
                Console.WriteLine("Welcome to Warehouse Management System");
                Console.WriteLine("Please select one of the following.");
                Console.WriteLine("1. Search Product");
                Console.WriteLine("2. Add/Remove Product");
                Console.WriteLine("3. Employee Look-Up");
                Console.WriteLine("4. Log-out");

                if (int.TryParse(Console.ReadLine(), out int menuSelection))
                   {
                        switch (menuSelection)
                            {
                                case 1:
                                    SearchProduct();
                                    Console.WriteLine("");
                                    break;
                                case 2:
                                    AddRemoveProduct();
                                    break;
                                case 3:
                                    EmployeeLookup();
                                    break;
                                case 4:
                                    Console.WriteLine("Logging out...");
                                    runningProgram = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }
                    }
                 else
                     {
                        Console.WriteLine("Invalid input. Please enter a number.");
                     }
            }    

        }

        public static void SearchProduct()
        {

          Console.WriteLine("Please enter the product name: "); 
          string? productName = Console.ReadLine();
          
          if(!string.IsNullOrWhiteSpace(productName))
          {
            DataAccess db = new();
            List<Product> productList = db.GetProduct(productName); 
        
                 if (productList.Count > 0)
                {
                    foreach (Product product in productList)
                    {
                        Console.WriteLine($"ProductID: {product.ProductID}");
                        Console.WriteLine($"Product Name: {product.ProductName}");
                        Console.WriteLine($"Product Class: {product.ProductClass}");
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine("No products found with the given name.");
                }        
          }    
          else
          {
            Console.WriteLine("Please enter a Product Name");
            throw new Exception();
          }
 
        }

        public static void AddRemoveProduct()
        {
            DataAccess db = new();

            Console.WriteLine("Are we adding or Removing an Product");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            
            int addRemove = Convert.ToInt32(Console.ReadLine());

            switch (addRemove)
            {
                case 1: 
                   
                    Console.WriteLine("Enter ProductID");
                    int productID = Convert.ToInt32(Console.ReadLine());

                    
                    Console.WriteLine("Enter ProductName");
                    string productName = Console.ReadLine();

                    
                    Console.WriteLine("Enter ProductClass");
                    string productClass = Console.ReadLine();

                    
                    Console.WriteLine("Enter ProductQuanity");
                    int productQuanity= Convert.ToInt32(Console.ReadLine());

                    db.AddProduct(productID, productName, productClass, productQuanity);
                    break;
                case 2:

                   Console.WriteLine("Please enter your ProductID to be removed from the system.");
                   productID = Convert.ToInt32(Console.ReadLine()); 
                   db.RemoveProduct(productID);

                    break;
            }
        }

        public static void EmployeeLookup()
        {
            Console.WriteLine("Please enter last name");
            string lastName = Console.ReadLine();
            DataAccess db = new();

            if (lastName != null)
            {
                db.EmployeeSearch(lastName);
            }
            else 
            {
                Console.WriteLine("Please enter a valid last name");
            }
        }


    }



}

