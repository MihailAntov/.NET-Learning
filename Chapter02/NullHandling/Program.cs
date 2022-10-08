using System;
using System.Collections.Generic;
using System.Linq;
#nullable enable
namespace NullHandling
{
    class Address
    {
        public string? Building;
        public string? Street;
        public string? City;
        public string? Region;
    }
    
    public class Program
    {
        
        public static void Main(string[] args)
        {
            
            var address = new Address();
            address.Building = null;
            address.Street = null;
            address.City = "London";
            address.Region = null;

            var home = ((address.Building)?.Length ?? 0);
            Console.WriteLine(home);
        }
    }
}