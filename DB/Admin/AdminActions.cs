using System.Data.Common;
using InventoryManagement;

class AdminActions
{
    internal static void CreateUser()
    {
        List<string> validRoles = new List<string> { "admin", "user", "sales"};

        DataAccess db = new();
        string userId = GenerateUserId();

        Console.Write("Please enter desired username: ");
        string? userName = Console.ReadLine();

        string password = Security.GenerateNewPassword();

        Console.WriteLine("Which Role will the user have?");
        string? role = Console.ReadLine().ToLower();

        if (!validRoles.Contains(role))
        {
            Console.WriteLine("Please enter a valid role. Admin, User, or Sales.");
        }
        else
        {
            db.NewUser(userId, userName, password);
        }
        
        Console.WriteLine($"New user {userName} successfully created");
    }


    static int userIdCounter = 0;

    internal static string GenerateUserId()
    {
       

        string prefix = "EMP";
        int currentCounter = System.Threading.Interlocked.Increment(ref userIdCounter);

        string userId = $"{prefix}{currentCounter:D5}";

        return userId;
    }
}