using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Models.EntityModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
        public static void SeedData()
        {
            var db = new DataContext();

            //check if the database table is empty
            if(!db.Employees.Any())
            {
                var initialEmployeee = new List<Employee>()
                {
                    new Employee { username = "employee_1", password = "1234"},
                    new Employee { username = "employee_2", password = "5678"}
                };

                db.AddRange(initialEmployeee);
                db.SaveChanges();
            }
        }
    }
}
