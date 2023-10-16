using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Reflection;

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
                Console.WriteLine("3. Customer Look-UpdateRowSource");
                Console.WriteLine("4. Log-out");

                if (int.TryParse(Console.ReadLine(), out int menuSelection))
                   {
                        switch (menuSelection)
                            {
                                case 1:
                                    SearchProduct();
                                    break;
                                case 2:
                                    AddRemoveProduct();
                                    break;
                                case 3:
                                    CustomerLookup();
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

        public static string SearchProduct()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            return "nada";
            
        }

        public static string AddRemoveProduct()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            return "nada";
        }

        public static string CustomerLookup()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            return "nada";
        }


    }



}

