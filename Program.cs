using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Reflection;
using Dapper;

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

               // if (int.TryParse(Console.ReadLine(), out int menuSelection))
               int menuSelection = 1;
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
                // else
                     {
                        Console.WriteLine("Invalid input. Please enter a number.");
                     }
            }    

        }

        public static void SearchProduct()
        {

          Console.WriteLine("Please enter the product name: "); 
          //string? productName = Console.ReadLine();
           string productName = "Sofa";
          
          if(!string.IsNullOrWhiteSpace(productName))
          {
            DataAccess db = new();
            List<Product> result = db.GetProduct(productName); 
                 
          }    
          else
          {
            Console.WriteLine("Please enter a Product Name");
            throw new Exception();
          }
 
        }

        public static string AddRemoveProduct()
        {
            throw new NotImplementedException();
        }

        public static string EmployeeLookup()
        {
            throw new NotImplementedException();
        }


    }



}

