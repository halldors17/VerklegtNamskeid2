using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using BookCave.Models.EntityModels;

namespace BookCave.Controllers
{
    
    public class BookController : Controller
    {
        private BookService _bookService;
        private AccountService _accountService;

        public BookController()
        {
            _bookService = new BookService();
            _accountService = new AccountService();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }
        [HttpPost]
        public IActionResult Search(string SearchBy, string SearchString)
        {
            var books = _bookService.GetBooksBySearch(SearchBy, SearchString);
            if(books.Equals(0))
            {
                return RedirectToAction("NothingFound");
            }
            return View(books);
        }

        public IActionResult NothingFound()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var books = _bookService.GetBookDetails(id);
            if(books == null)
            {
                return Content("Not Found");
            }
            return View(books);
        }
        [HttpPost]
        public IActionResult Details(int id, string comment, int rating)
        {
            var newComment = new Comment
            {
                BookComment = comment,
                Rating = rating,
                BookId = id
                //user
            };

            if(ModelState.IsValid)
            {
                _accountService.AddComment(newComment);
            }

            //var books = _bookService.GetBookDetails(id);
            
            return RedirectToAction("Details");
        }
        
    }
}
