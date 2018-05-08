using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Models.EntityModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Session;

namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            //to initialize the database
            //SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        //To initialize the database
        /*public static void SeedData()
        {
            var db = new DataContext();

            //check if the authors table in the database table is empty
            if(!db.Authors.Any())
            {
                var initialAuthors = new List<Author>()
                {
                    new Author { Name = "Patrick Rothfuss", 
                    Description = "Patrick James Rothfuss (born June 6, 1973) is an American writer of epic fantasy.", 
                    BookIdList = new List<BookIdItem>(){ new BookIdItem(){ BookId = 1 }, new BookIdItem(){ BookId = 2 }, new BookIdItem(){ BookId = 3 }}},
                    
                    new Author { Name = "Patrick Ness", 
                    Description = "Patrick Ness (born 17 October 1971) is a British-American author, journalist, lecturer, and screenwriter.", 
                    BookIdList = new List<BookIdItem>(){ new BookIdItem(){ BookId = 4 }, new BookIdItem(){ BookId = 5 }, new BookIdItem(){ BookId = 5 }}},
                };

                db.AddRange(initialAuthors);
                db.SaveChanges();
            }

             //check if the books table in the database table is empty
            if(!db.Books.Any())
            {
                var initialBooks = new List<Book>()
                {
                    new Book {
                        Title = "The Wise Man's Fear",
                        AuthorIdList = new List<AuthorIdItem>(){ new AuthorIdItem(){ AuthorId = 1 }},
                        Publisher = "DAW Books", YearPublished = 2011, Price = 35, 
                        LanguageList = new List<LanguageItem>(){ new LanguageItem(){ Language = "English" }},
                        Pages = 994, Minutes = 2569, Audio = true, Ebook = true, Paperback = true, 
                        CategoryIdList = new List<CategoryIdItem>(){ new CategoryIdItem(){ CategoryId = 1 }},
                        Description = "In The Wise Man's Fear, Kvothe takes his first steps on the path of the hero and learns how difficult life can be when a man becomes a legend in his own time.",
                        Stock = 1000, Rating = 4.58
                    }
                };

                db.AddRange(initialBooks);
                db.SaveChanges();
            }

            //check if the orders table in the database table is empty
            if(!db.Orders.Any())
            {
                var initialOrders = new List<Order>()
                {
                    new Order {
                        OrderDate = new DateTime(2018,04,30), 
                        ShippingInfo = new ShippingInfo { Street = "Dúfnahólar 10", City = "Reykjavík", PostalCode = 111, Country = "Ísland" },
                        Status = "Paid", Price = 30, PaidDate = new DateTime(2018,04,30), CustomerId = 1, 
                        OrderItems = new List<OrderItem>(){ new OrderItem(){ OrderId = 1, BookId = 1, Quantity = 1, Price = 30 }}
                    }
                };

                db.AddRange(initialOrders);
                db.SaveChanges();
            }
        }*/
    }
}
