namespace CryptographyLib
{
    public class User
    {
        public string Name {get; set;}
        public string Salt {get; set;}
        public string SaltedHashedPassword{get; set;}
        public string[] Roles{get; set;}
        public string EncryptedCardNumber{get;set;}
    }
}