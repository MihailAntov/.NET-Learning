using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Packt.Shared;
using NorthwindWeb;
using static System.Console;
namespace NorthwindWeb.Pages
{
    public class FactorialsModel : PageModel
    {
        public long Number;
        public long Factorial(long number)
        {
            if(number < 1)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else 
            {
                return number * Factorial(number-1);
            }
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Times Table Generator";
        }
    }
}