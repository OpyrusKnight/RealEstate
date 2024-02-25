using System.Security.Cryptography;
using System.Text;

namespace RealEstate.Models
{
    public class Security
    {
        public static bool IsValidUserCredentials(string username, string password, out Utilisateur user)
        {
            try
            {
                user = PersistentData.utilisateurs.FirstOrDefault(u => u.nomutilisateur == username)!;
                if (user != null)
                {
                    if (user.motpasse == password)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                user = null!;
                return false;
            }
        }

        public static string Hashing(string plainText)
        {
            byte[] input = Encoding.UTF8.GetBytes(plainText);
            SHA256 encryptor = SHA256.Create();
            var hashBytes = encryptor.ComputeHash(input);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2")); // "x2" means hexadecimal with two digits
            }
            return sb.ToString();
        }
    }
}
