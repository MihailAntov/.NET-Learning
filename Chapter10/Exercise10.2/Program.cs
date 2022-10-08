using CryptographyLib;
using System.IO;
using System.Collections;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using static System.Console;

WriteLine("Select option:");
WriteLine("1. Encrypt cards\n2. Decrypt cards");
string choice = ReadLine();
chooseAgain:
switch (choice)
{
    case "1":
    WorkWithCardNumbers.EncryptCard();
    break;
    case "2":
    WorkWithCardNumbers.DecryptCard();
    break;
    default:
    WriteLine("Invalid choice.");
    goto chooseAgain;
}