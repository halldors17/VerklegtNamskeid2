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
    
    public class BookController : Controller
    {
        private BookService _bookService;
        public BookController()
        {
            _bookService = new BookService();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }
        [HttpPost]
        public IActionResult Index(string SearchString)
        {
            var books = _bookService.GetBooksBySearch(SearchString);
            return View(books);
        }
        /*public IActionResult Details(int id)
        {
            var books = _bookService.GetBookDetails(id);
            if(books == null)
            {
                return Content("Not Found");
            }
            return View(books);
        }*/
    }
}
