using Microsoft.EntityFrameworkCore;
namespace Exercise02
{
    public class Northwind : DbContext
    {
        public DbSet<Customer> Customers{get; set;}
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            {
                string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
                optionsBuilder.UseSqlite($"Filename={path}");
            }
    }
}