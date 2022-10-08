using static System.Console;
using Exercise02;
static void DisplayCompaniesByCity()
{
    using (var db = new Northwind())
    {
        
        var allCities = db.Customers.Select(customer=>customer.City).Distinct();
        WriteLine("Cities to choose from:");
        WriteLine(string.Join(", ", allCities));

        Write("Enter the name of a city:");
        string input = ReadLine();
        var filteredCompanies = db.Customers.Where(customer=>customer.City == input);
        WriteLine($"There are {filteredCompanies.Count()} companies in {input}");
        foreach(var item in filteredCompanies)
        {
            WriteLine(item.CompanyName);
        }
    }
}
DisplayCompaniesByCity();
