using Packt.Shared;

namespace Northwind.Mvc.Models;

public class CategoryView
{
    public Category? Category {get; set;}
    public IEnumerable<Product>? Products {get; set;}
    public CategoryView(Category category, IEnumerable<Product> products)
    {
        Category = category;
        Products = products;
    }
}