using System.Security.Cryptography;
using System.Text;

namespace Task3;

public class HashMac
{
    private const int KeySize = 32;

    public static byte[] GenerateRandomKey()
    {
        using (var randomNumberGenerator = new RNGCryptoServiceProvider())
        {
            var randomNumber = new byte[KeySize];
            randomNumberGenerator.GetBytes(randomNumber);

            return randomNumber;
        }
    }

    public static byte[] GenerateHMAC(string text, byte[] keyBytes)
    {
        var encoding = new ASCIIEncoding();

        var textBytes = encoding.GetBytes(text);

        byte[] hashBytes;

        using (var hash = new HMACSHA256(keyBytes))

        {
            hashBytes = hash.ComputeHash(textBytes);
        }

        return hashBytes;
    }
}