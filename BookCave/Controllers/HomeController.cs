using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Http;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        private BookService _bookService;

        public HomeController() 
        {
            _bookService = new BookService();
        }
          public IActionResult Index(string id)
        {
            if(id == "Stafrodsrod")
            {
                var alphabooks = _bookService.GetAllBooksAlpha();
                return View(alphabooks);
            }
            if(id == "LH")
            {
                var LHbooks = _bookService.GetAllBooksLH();
                return View(LHbooks);
            }
            if( id == "HL")
            {
            var HLbooks = _bookService.GetAllBooksHL();
            return View(HLbooks);
            }
            if(id == "Einkunn")
            {
                var EinkunnBooks = _bookService.GetAllBooksEinkunn();
                return View(EinkunnBooks);
            }
            else
            {
            var books = _bookService.GetAllBooks();
            return View(books);
            }
        }
        public IActionResult Top10()
        {
            var topBooks = _bookService.GetTop10();
            return View(topBooks);
        }
        public IActionResult Discount()
        {
            var discountBooks = _bookService.GetDiscount();
            return View(discountBooks);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
