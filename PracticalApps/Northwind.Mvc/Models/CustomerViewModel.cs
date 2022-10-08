using Packt.Shared;
namespace Northwind.Mvc.Models;
public record CustomerViewModel
(
    Customer Customer,
    bool HasErrors,
    IEnumerable<string> ValidationErrors
);