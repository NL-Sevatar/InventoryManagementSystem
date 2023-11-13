using System.Data.Common;
using InventoryManagement;

class AdminActions
{
    private static void CreateUser()
    {
         DataAccess db = new();

        Console.Write("Please enter desired username: ");
        string? firstName = Console.ReadLine();

        Console.Write("Please enter user password");
        string password = Console.ReadLine();
        string verifyPassword;

        if (verifyPassword != password)
        {
            Console.Write("Please renter user password.");
            verifyPassword = Console.ReadLine();
        }
        else
        {
            int salt = db.GenerateSalt();
        }
        
        
         using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("connectDB"));
           connection.Open();
           
            if (connection.State == ConnectionState.Open)
            {
                return connection.Query<User>($"");
            }
            else
            {
                Console.WriteLine("Failed Connection");
                throw new Exception();
            }


        Console.WriteLine("$"New user {userName} successfully created");
    }
}