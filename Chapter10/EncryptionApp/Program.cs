using CryptographyLib;
using System.Security.Cryptography;
using static System.Console;
Write("Enter a message that you wish to encrypt: ");
string message = ReadLine();
Write("Enter a password: ");
string password = ReadLine();
string cryptoText = Protector.Encrypt(message, password);
WriteLine($"Encrypted text: {cryptoText}");
WriteLine();
Write("Enter the password: ");
string password2 = ReadLine();
try
{
    string clearText = Protector.Decrypt(cryptoText, password2);
    WriteLine($"Decrypted text: {clearText}");
}
catch (CryptographicException ex)
{
    WriteLine($"You entered the wrong password! \nMore details:\n{ex.Message}");
}
catch (Exception ex)
{
    WriteLine($"Non-cryptographic exception: {ex.GetType().Name}, {ex.Message}");
}
