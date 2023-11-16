using System.Security.Cryptography;
using System.Text;

namespace InventoryManagement
{
    class Security
    {

    internal static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
           
           byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
           byte[] saltBytes = Convert.FromBase64String(salt);

           byte[] combinedBytes = new byte[passwordBytes.Length + saltBytes.Length];

           Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
           Buffer.BlockCopy(saltBytes, 0, combinedBytes, passwordBytes.Length, saltBytes.Length);

           byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("x2"));
            }

            return builder.ToString();

        }
    }
    public static void AuthenticateUser(string username, string passwordHash)
    {
        //  User user
        throw new NotImplementedException();
    }

    internal static string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }

        return Convert.ToBase64String(saltBytes);
    }

    internal static string GenerateNewPassword()
    {
        Console.Write("Please enter user password");
        string? password = Console.ReadLine();
        string? verifyPassword = "someunuseable password outside the scope.";

        if (verifyPassword != password)
        {
            Console.Write("Please renter user password.");
            verifyPassword = Console.ReadLine();
        }
        else
        {
            string salt = Security.GenerateSalt();
            string newPassword = HashPassword(password, salt);
            Console.WriteLine($"{newPassword}");
            return newPassword;
        }     
    }
  /*   internal static string RetrieveSalt()
    {
        throw new Exception NotImplementedException;
    } */

    }
}