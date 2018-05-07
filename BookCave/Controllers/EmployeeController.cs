using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using BookCave.Models.ViewModels;

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
            var books = _bookService.GetSalesBooksInfo();
            return View(books);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
/*
        [HttpPost]
        public IActionResult AddBook(BookDetailViewModel book)
        {
            if(ModelState.IsValid)
            {
                _bookService.AddBook(book);
                return RedirectToAction("AddBook");
            }

            return View(book);
        }
*/
/* 
        [HttpGet]
        public IActionResult ChangeBook(int id)
        {
            var book = _bookService.GetSalesBooks(id);
            return View(book);
        }
*/
/*
        [HttpPost]
        public IActionResult ChangeBook(int id)
        {
            
            return View();
        }
*/
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
