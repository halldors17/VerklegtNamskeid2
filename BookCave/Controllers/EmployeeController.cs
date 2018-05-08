using Microsoft.AspNetCore.Mvc;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using BookCave.Models.InputModels;

namespace BookCave.Controllers
{
    [Authorize(Roles = "Employee")]
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
            ViewBag.Title = "Innranet forsíða";
            return View();
        }

        public IActionResult Books()
        {
            ViewBag.Title = "Innranet bækur";
            var books = _bookService.GetSalesBooksInfo();
            return View(books);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            ViewBag.Title = "Innranet bækur";
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(InputBookModel book)
        {
            if(ModelState.IsValid)
            {
                _bookService.AddBook(book);
            }

            return RedirectToAction("AddBook");
        }

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
            ViewBag.Title = "Innranet höfundar";
            return View();
        }

        public IActionResult Categories()
        {
            ViewBag.Title = "Innranet flokkar";
            return View();
        }

        public IActionResult Sales()
        {
            ViewBag.Title = "Innranet sala";
            return View();
        }
    }
}
