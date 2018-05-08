using BookCave.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BookCave.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CategoryIdItem> CategoryIdItem { get; set; }
        public DbSet<BookIdItem> BookIdItem { get; set; }
        public DbSet<ShippingInfo> ShippingInfo { get; set;}
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H39;Persist Security Info=False;User ID=VLN2_2018_H39_usr;Password=r!chIron80;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}