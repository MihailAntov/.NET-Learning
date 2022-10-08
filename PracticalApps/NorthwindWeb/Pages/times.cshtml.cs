using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Packt.Shared;
using NorthwindWeb;
using static System.Console;
namespace NorthwindWeb.Pages
{
    public class TimesModel : PageModel
    {
        public int tableNumber;
        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Times Table Generator";
        }
    }
}