using System.Security.Cryptography;
using System.Text;

namespace InventoryManagement
{
    class Security
    {

    static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

        }
    }
    public static void AuthenticateUser(string username, string passwordHash)
    {
        User user 
        throw new NotImplementedException();
    }
    }
}