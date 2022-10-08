using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Packt.Shared;
namespace NorthwindWeb.Pages
{
    public class OrderModel : PageModel
    {
        public IEnumerable<Order> Orders {get; set;}
        public string QueryID {get; set;}
        public string Phone {get; set;}
        public string Address {get; set;}
        public Customer QueriedCustomer {get; set;}
        private NorthwindContext db;
        public OrderModel(NorthwindContext injectedContext)
        {
            db = injectedContext;
        }


        public void OnGet()
        {
            QueryID = Request.QueryString.ToString().Substring(1);
            ViewData["Title"] = "Northwind B2B - Orders by";
            QueriedCustomer = db.Customers.Where(c => c.CustomerId == QueryID).FirstOrDefault();
            Orders = db.Orders.Where(c=> c.CustomerId == QueriedCustomer.CustomerId);
            Phone = QueriedCustomer.Phone;
            Address = QueriedCustomer.Address;

        }
    }
}