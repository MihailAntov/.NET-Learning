using CryptographyLib;
using System.IO;
using System.Collections;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using static System.Console;
namespace CryptographyLib
{
    public class WorkWithCardNumbers
    {
        public static void EncryptCard()
        {
            Console.Clear();
            string XmlPath = Path.Combine(Environment.CurrentDirectory, "Cards.xml");
            var xs = new XmlSerializer(typeof(customers));
            List<EncryptedCustomer> EncryptedCustomers = new List<EncryptedCustomer> { };
            using (FileStream XmlLoad = File.Open(XmlPath, FileMode.Open))
            {
                var loadedCustomers = (customers)xs.Deserialize(XmlLoad);
                foreach (customer customer in loadedCustomers.customerlist)
                {
                    EncryptedCustomer nextCustomer = new EncryptedCustomer();
                    var salt = new Byte[16];
                    var random = RandomNumberGenerator.Create();
                    random.GetBytes(salt);
                    var saltText = Convert.ToBase64String(salt);
                    var EncryptedCustomer = new customer();
                    var sha = SHA256.Create();

                    string saltedPassword = customer.password + saltText;
                    nextCustomer.saltedHashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
                    nextCustomer.name = customer.name;
                    nextCustomer.salt = saltText;
                    nextCustomer.encryptedCardNumber = Protector.Encrypt(customer.creditcard, nextCustomer.saltedHashedPassword);
                    EncryptedCustomers.Add(nextCustomer);

                }
            }
            string savePath = Path.Combine(Environment.CurrentDirectory, "EncryptedCards.xml");
            xs = new XmlSerializer(typeof(List<EncryptedCustomer>));
            using (FileStream XmlSave = File.Create(savePath))
            {
                xs.Serialize(XmlSave, EncryptedCustomers);
            }
        }

        public static void DecryptCard()
        {
            string loadPath = Path.Combine(Environment.CurrentDirectory, "EncryptedCards.xml");
            var xs = new XmlSerializer(typeof(List<EncryptedCustomer>));
            using (FileStream xmlLoad = File.Open(loadPath, FileMode.Open))
            {
                List<EncryptedCustomer> loadedEncryptedCustomers = (List<EncryptedCustomer>)xs.Deserialize(xmlLoad);

                Write("Please enter your username:");
                string username = ReadLine();
                for (int i = 0; i < loadedEncryptedCustomers.Count; i++)
                {


                    if (loadedEncryptedCustomers[i].name != username)
                    {
                        if (i == loadedEncryptedCustomers.Count - 1)
                        {
                            WriteLine("No such username found.");
                        }
                        continue;

                    }
                    else
                    {


                        Write("Please enter your password:");
                        string password = ReadLine();
                        var shaCheck = SHA256.Create();
                        string passCheck = password + loadedEncryptedCustomers[i].salt;
                        string hashCheck = Convert.ToBase64String(shaCheck.ComputeHash(Encoding.Unicode.GetBytes(passCheck)));
                        if (hashCheck == loadedEncryptedCustomers[i].saltedHashedPassword)
                        {
                            WriteLine("Log in successful.");
                            WriteLine("Your card number is:");
                            WriteLine(Protector.Decrypt(loadedEncryptedCustomers[i].encryptedCardNumber, loadedEncryptedCustomers[i].saltedHashedPassword));
                            break;

                        }
                        else
                        {
                            WriteLine("Incorrect password.");
                            break;
                        }
                    }


                }


            }
        }
    }
    [XmlRoot(ElementName = "customer")]
public class customer
{
    public customer() { }
    public string name { get; set; }
    public string password { get; set; }
    public string saltedHashedPassword { get; set; }
    public string creditcard { get; set; }
    public string encryptedCardNumber { get; set; }
}
public class EncryptedCustomer
{
    public EncryptedCustomer() { }
    public string name { get; set; }
    public string saltedHashedPassword { get; set; }
    public string salt;
    public string encryptedCardNumber;
}
[XmlRoot(ElementName = "customers")]
public class customers
{

    [XmlElement(ElementName = "customer")]
    public List<customer> customerlist { get; set; }
    public customers() { }

}

}