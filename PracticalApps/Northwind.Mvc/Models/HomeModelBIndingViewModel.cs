namespace Northwind.Mvc.Models;
public record HomeModelBIndingViewModel
(
    Thing Thing,
    bool HasErrors,
    IEnumerable<string> ValidationErrors
);