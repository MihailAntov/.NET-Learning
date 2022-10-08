using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Packt.Shared;
namespace NorthwindWeb.Pages
{
    public class CustomersModel : PageModel
    {
        public IEnumerable<Customer> Customers {get; set;}
        private NorthwindContext db;
        public CustomersModel(NorthwindContext injectedContext)
        {
            db = injectedContext;
        }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Suppliers";
            Customers = db.Customers.OrderBy(c => c.Country).ThenBy(c => c.CompanyName);
        }
    }
}