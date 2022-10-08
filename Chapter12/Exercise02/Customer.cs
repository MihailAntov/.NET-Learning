using System.ComponentModel.DataAnnotations;
namespace Exercise02
{
    public class Customer
    {
        [Required]
        [StringLength(5)]
        public string CustomerID{get; set;}

        [Required]
        [StringLength(40)]
        public string CompanyName{get; set;}
        [StringLength(15)]
        public string City{get; set;}
    }
}