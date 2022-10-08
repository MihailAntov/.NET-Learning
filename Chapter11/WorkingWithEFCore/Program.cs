using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;
using System.Runtime.Serialization;
using System.Text.Json;
using jsst = System.Text.Json.JsonSerializer;


//QueryingCategories();
//QueryingProducts();
//QueryingWithLike();
//if (AddProduct(6, "Bob's Burgers", 500M))
//{
//    WriteLine("Add product successful.");
//}
//if (IncreaseProductPrice("Bob", 20M))
//{
//    WriteLine("Update product price successful.");
//}
//int deleted = DeleteProducts("Bob");
//WriteLine($"{deleted} product(s) were deleted.");
//ListProducts();
Clear();
ChooseOption:
Write("Please select option: \n1.Query Categories\n2.Query Products\n3.QueryWithLike");
Write("\n4.Add a product\n5.Increase product price\n6.Delete a product\n7.Serialize as XML\n8.Serialize as JSON\n9.Serialize as SOAP\n");
ConsoleKeyInfo choiceInput = ReadKey();
switch (choiceInput.KeyChar)
{
    case '1':
        QueryingCategories();
        break;
    case '2':
        QueryingProducts();
        break;
    case '3':
        QueryingWithLike();
        break;
    case '4':
        if (AddProduct(6, "Bob's Burgers", 500M))
        {
            WriteLine("Add product successful.");
        }
        ListProducts();
        break;
    case '5':
        if (IncreaseProductPrice("Bob", 20M))
        {
            WriteLine("Update product price successful.");
        }
        ListProducts();
        break;
    case '6':
        int deleted = DeleteProducts("Bob");
        WriteLine($"{deleted} product(s) were deleted.");
        ListProducts();
        break;
    case '7':
        SerializeAsXml();
        break;
    case '8':
        SerializeAsJson();
        break;
    case '9':
        SerializeAsTextJson();
        break;
    default:
    WriteLine("Invalid choice. Please try again.");
    goto ChooseOption;    
}
static void QueryingCategories()
{
    using (var db = new Northwind())
    {
        var loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());
        WriteLine("Categories and how many products they have:");
        // a query to get all categories and their related products
        IQueryable<Category> cats;// = db.Categories;
        //.Include(c => c.Products);
        db.ChangeTracker.LazyLoadingEnabled = false;
        Write("Enable eager loading? (Y/N):");
        bool eagerloading = (ReadKey().Key == ConsoleKey.Y);
        bool explicitloading = false;
        WriteLine();
        if (eagerloading)
        {
            cats = db.Categories.Include(c => c.Products);
        }
        else
        {
            cats = db.Categories;
            Write("Enable explicit loading? (Y/N):");
            explicitloading = (ReadKey().Key == ConsoleKey.Y);
            WriteLine();
        }

        foreach (Category c in cats)
        {
            if (explicitloading)
            {
                Write($"Explicitly load products for {c.CategoryName}? (Y/N):");
                ConsoleKeyInfo key = ReadKey();
                WriteLine();
                if (key.Key == ConsoleKey.Y)
                {
                    var products = db.Entry(c).Collection(c2 => c2.Products);
                    if (!products.IsLoaded) products.Load();
                }
            }
            WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
        }
    }
}
static void QueryingProducts()
{
    using (var db = new Northwind())
    {
        var loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());
        WriteLine("Products that cost more than a price, highest at top.");
        string input;
        double price;
        do
        {
            Write("Enter a product price:");
            input = ReadLine();
        } while (!double.TryParse(input, out price));
        IQueryable<Product> prods = db.Products
        .TagWith("Products filtered by price and sorted.")
        .Where(product => (double)product.Cost > price)
        .OrderByDescending(product => (double)product.Cost);

        foreach (Product item in prods)
        {
            WriteLine($"{item.ProductID}: {item.ProductName} costs {item.Cost:C} and has {item.Stock} in stock.");
        }
    }
}
static void QueryingWithLike()
{
    using (var db = new Northwind())
    {
        var loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());
        Write("Enter part of a product name:");
        string input = ReadLine();
        IQueryable<Product> prods = db.Products.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
        foreach (Product item in prods)
        {
            WriteLine($"{item.ProductName} has {item.Stock} units in stock. Discontinued? {item.Discontinued}");
        }
    }
}
static bool AddProduct(int categoryID, string productName, decimal? price)
{
    using (var db = new Northwind())
    {
        var newProduct = new Product
        {
            CategoryID = categoryID,
            ProductName = productName,
            Cost = price
        };

        //mark product as added in change tracking
        db.Products.Add(newProduct);

        //save tracked change to database
        int affected = db.SaveChanges();
        return (affected == 1);
    }
}

static void ListProducts()
{
    using (var db = new Northwind())
    {
        WriteLine("{0,-3} {1,-35} {2,8} {3, 5} {4}", "ID", "Product Name", "Cost", "Stock", "Disc.");
        foreach (var item in db.Products.OrderByDescending(p => (double)p.Cost))
        {
            WriteLine("{0:000} {1,-35} {2,8:C} {3,5} {4}", item.ProductID, item.ProductName, item.Cost, item.Stock, item.Discontinued);
        }
    }

}
static bool IncreaseProductPrice(string name, decimal amount)
{
    using (var db = new Northwind())
    {
        //get first product whose name starts with name
        Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(name));
        updateProduct.Cost += amount;
        int affected = db.SaveChanges();
        return (affected == 1);
    }
}
static int DeleteProducts(string name)
{
    using (var db = new Northwind())
    {
        using (IDbContextTransaction t = db.Database.BeginTransaction())
        {
            WriteLine($"Transaction isolation level: {t.GetDbTransaction().IsolationLevel}");
            IEnumerable<Product> products = db.Products.Where(p => p.ProductName.StartsWith(name));
            db.Products.RemoveRange(products);
            int affected = db.SaveChanges();
            t.Commit();
            return affected;
        }
    }
}

static void SerializeAsXml()
{
    using (var db = new Northwind())
    {
        var loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());
        //a query to get all categories and their related products
        
        var xs = new XmlSerializer(typeof(List<SerializedCategory>));
        SerializedCategory nextCategory;
        SerializedProduct nextProduct;
        List<SerializedCategory> serializedCategories = new List<SerializedCategory>();
        string path = Combine(CurrentDirectory, "Nortwind.xml");
        using (FileStream stream = File.Create(path))
        {
            IQueryable<Category> prods = db.Categories.Include(c => c.Products);
            
            foreach (Category c in prods)
            {
                nextCategory = new SerializedCategory();
                nextCategory.Products = new List<SerializedProduct>();
                nextCategory.CategoryID = c.CategoryID;
                nextCategory.CategoryName = c.CategoryName;
                nextCategory.Description = c.Description;
                foreach(Product p in c.Products)
                {
                    nextProduct = new SerializedProduct();
                    nextProduct.ProductID = p.ProductID;
                    nextProduct.ProductName = p.ProductName;
                    nextProduct.Cost = p.Cost;
                    nextProduct.Discontinued = p.Discontinued;
                    nextProduct.Stock = p.Stock;
                    nextProduct.CategoryID = c.CategoryID;
                    nextCategory.Products.Add(nextProduct);
                }
                serializedCategories.Add(nextCategory);
            }
            xs.Serialize(stream, serializedCategories);
            
        }
        
        WriteLine($"Size of XML serialization: {new FileInfo(path).Length} bytes.");
        
    }
}
static void SerializeAsJson()
{
    using (var db = new Northwind())
    {
        string path = Combine(CurrentDirectory, "Nortwind.json");
        var jss = new Newtonsoft.Json.JsonSerializer();
        var loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());
        //a query to get all categories and their related products
        SerializedCategory nextCategory;
        SerializedProduct nextProduct;
        List<SerializedCategory> serializedCategories = new List<SerializedCategory>();
        using (StreamWriter jsonStream = File.CreateText(path))
        {
            IQueryable<Category> prods = db.Categories.Include(c => c.Products);
            
            foreach (Category c in prods)
            {
                nextCategory = new SerializedCategory();
                nextCategory.Products = new List<SerializedProduct>();
                nextCategory.CategoryID = c.CategoryID;
                nextCategory.CategoryName = c.CategoryName;
                nextCategory.Description = c.Description;
                foreach(Product p in c.Products)
                {
                    nextProduct = new SerializedProduct();
                    nextProduct.ProductID = p.ProductID;
                    nextProduct.ProductName = p.ProductName;
                    nextProduct.Cost = p.Cost;
                    nextProduct.Discontinued = p.Discontinued;
                    nextProduct.Stock = p.Stock;
                    nextProduct.CategoryID = c.CategoryID;
                    nextCategory.Products.Add(nextProduct);
                }
                serializedCategories.Add(nextCategory);
            }
            jss.Serialize(jsonStream, serializedCategories);
            WriteLine($"Size of JSON serialization: {new FileInfo(path).Length} bytes.");

        }
    }
}
static void SerializeAsTextJson()
{
    using (var db = new Northwind())
    {
        string path = Combine(CurrentDirectory, "NortwindText.json");
        
        var loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());
        //a query to get all categories and their related products
        
        var xs = new XmlSerializer(typeof(List<SerializedCategory>));
        SerializedCategory nextCategory;
        SerializedProduct nextProduct;
        List<SerializedCategory> serializedCategories = new List<SerializedCategory>();
        
        
        using (StreamWriter jsonStreamText = File.CreateText(path))
        {
            IQueryable<Category> prods = db.Categories.Include(c => c.Products);
            
            foreach (Category c in prods)
            {
                nextCategory = new SerializedCategory();
                nextCategory.Products = new List<SerializedProduct>();
                nextCategory.CategoryID = c.CategoryID;
                nextCategory.CategoryName = c.CategoryName;
                nextCategory.Description = c.Description;
                foreach(Product p in c.Products)
                {
                    nextProduct = new SerializedProduct();
                    nextProduct.ProductID = p.ProductID;
                    nextProduct.ProductName = p.ProductName;
                    nextProduct.Cost = p.Cost;
                    nextProduct.Discontinued = p.Discontinued;
                    nextProduct.Stock = p.Stock;
                    nextProduct.CategoryID = c.CategoryID;
                    nextCategory.Products.Add(nextProduct);
                }
                serializedCategories.Add(nextCategory);
            }
            
            string jsonString = JsonSerializer.Serialize(serializedCategories); 
            jsonStreamText.Write(jsonString);
            WriteLine($"Size of JSON text serialization: {new FileInfo(path).Length} bytes.");

        }
    }
    
}

public class SerializedCategory
{  
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }

    public string Description { get; set; }
    public List<SerializedProduct> Products {get; set;}
    public SerializedCategory(){}
}
public class SerializedProduct
{
    public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? Cost { get; set; }
        public short? Stock { get; set; }
        public bool Discontinued { get; set; }

        // these two define the foreign key relationship
        // to the Categories table
        public int CategoryID { get; set; }
}
