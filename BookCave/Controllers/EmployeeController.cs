using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;

namespace BookCave.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService _employeeService;
        private BookService _bookService;

        public EmployeeController() 
        {
            _bookService = new BookService();
            _employeeService = new EmployeeService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Books()
        {
            var books = _bookService.GetSalesBooks();
            return View(books);
        }

        public IActionResult ChangeBook(int id)
        {
            return View();
        }

        public IActionResult Authors()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult Sales()
        {
            return View();
        }
    }
}
