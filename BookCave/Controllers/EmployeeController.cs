using System.Linq;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;

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
