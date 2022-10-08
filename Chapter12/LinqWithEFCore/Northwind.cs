using Microsoft.EntityFrameworkCore;

namespace LinqWithEFCore
{
    public class Northwind : DbContext
    {
        //these properties map to tables in the database
        public DbSet<Category> Categories {get; set;}
        public DbSet<Product> Products {get; set;}
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            {
                string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
                optionsBuilder.UseSqlite($"Filename={path}");
            }
        
    }
}