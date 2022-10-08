﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Northwind.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Northwind.Common;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;




namespace Northwind.Mvc.Controllers;



public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NorthwindContext db;
    private readonly IHttpClientFactory clientFactory;

    public HomeController(ILogger<HomeController> logger, NorthwindContext injectedContext, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        db = injectedContext;
        clientFactory = httpClientFactory;
    }

    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> Index()
    {
       // _logger.LogError("This is a serious error (not really)");
       // _logger.LogWarning("This is your first warning.");
       // _logger.LogWarning("This is your second warning.");
       // _logger.LogInformation("I am in the index method of the HomeController.");
        try
        {
            HttpClient client = clientFactory.CreateClient(
                name: "Minimal.WebApi"
            );
            HttpRequestMessage request = new(
                method: HttpMethod.Get, requestUri: "api/weather"
            );
            HttpResponseMessage response = await client.SendAsync(request);
            ViewData["weather"] = await response.Content.
            ReadFromJsonAsync<WeatherForecast[]>();
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"The Minimal.WebApi service is not responding. Exception: {ex.Message}");
            ViewData["weather"] = Enumerable.Empty<WeatherForecast>().ToArray();
        }
        HomeIndexViewModel model = new(
            VisitorCount: (new Random()).Next(1, 1001),
            Categories: await db.Categories.ToListAsync(),
            Products: await db.Products.ToListAsync()
        );
        return View(model);
    }

    public IActionResult ModelBinding()
    {
        return View(); // the page with a form to submit
    }

    public IActionResult ProductsThatCostMoreThan(decimal? price)
    {
        if (!price.HasValue)
        {
            return BadRequest("You must pass a product price in the query string, for example /Home/ProductsThatCostMoreThan?price=50");
        }
        IEnumerable<Product> model = db.Products
        .Include(p=>p.Category)
        .Include(p=>p.Supplier)
        .Where(p => p.UnitPrice > price);

        if (!model.Any())
        {
            return NotFound($"No products cost more than {price:C}");
        }

        ViewData["MaxPrice"] = price.Value.ToString("C", new CultureInfo("en-IE"));
        return View(model);
    }

    [HttpPost]
    public IActionResult ModelBinding(Thing thing)
    {
        HomeModelBIndingViewModel model = new(
            thing, 
            !ModelState.IsValid, 
            ModelState.Values.SelectMany(state=>state.Errors).
                Select(error=>error.ErrorMessage)
            );
            return View(model);
    }
    public async Task<IActionResult> ProductDetail(int? id)
    {
        if (!id.HasValue)
        {
            return BadRequest("You must pass a product ID in the route, for example, /Home/ProductDetail/21");
        }
        Product? model = await db.Products.SingleOrDefaultAsync(p=> p.ProductId == id);
        if (model == null)
        {
            return NotFound($"ProductId {id} not found.");
        }

        return View(model);//pass model to view and then return result
    }

    public async Task<IActionResult> CategoryDetail(int? id)
    {
        if (!id.HasValue)
        {
            return BadRequest("You must pass a category ID in the route, for example /Home/CategoryDetail/3");
        }
        Category? Category = await db.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);
        if (Category == null)
        {
            return NotFound($"CategoryId {id} not found.");
        }
        IList<Product> Products = await db.Products.Where(p => p.CategoryId == id).ToListAsync();   
        CategoryView model = new CategoryView(Category, Products);
        return View(model);
    }
    [HttpGet]
    public async Task<IActionResult> Customers(string country)
    {
        string uri;
        if (string.IsNullOrEmpty(country))
        {
            ViewData["Title"] = "All Customers Worldwide";
            uri = "api/customers/";
        }
        else
        {
            ViewData["Title"] = $"Customers in {country}";
            uri = $"api/customers/?country={country}";
        }

        HttpClient client = clientFactory.CreateClient(
            name: "Northwind.WebApi");
        
        HttpRequestMessage request = new(
            method: HttpMethod.Get, requestUri: uri
        );
        HttpResponseMessage response = await client.SendAsync(request);
        IEnumerable<Customer>? model = await response.Content
        .ReadFromJsonAsync<IEnumerable<Customer>>();

        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Customers()

    {

        HttpClient client = clientFactory.CreateClient(
            name: "Northwind.WebApi");
        
            
        HttpRequestMessage request = new(HttpMethod.Post, "api/customers");
        HttpResponseMessage response = await client.SendAsync(request);
        IEnumerable<Customer>? model = await response.Content.ReadFromJsonAsync<IEnumerable<Customer>>();

        return View(
            model
        );
    }

    public IActionResult AddCustomer()
    {
        return View();
    }

    [Route("private")]
    [Authorize(Roles="Administrators")]
    public IActionResult Privacy()
    {
        return View();
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
