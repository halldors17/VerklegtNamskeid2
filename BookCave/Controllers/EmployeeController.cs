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

 
        [HttpGet]
        public IActionResult ChangeBook(int id)
        {
            var book = _bookService.GetBookDetails(id);

            var inputBook = new InputBookModel 
            {
                Title = book.Title,
                CategoryList = book.CategoryList,
                Image = book.Image,
                Price = book.Price,
                Publisher = book.Publisher,
                AuthorList = book.AuthorList,
                Rating = book.Rating,
                Pages = book.Pages,
                Description = book.Description,
                Stock = book.Stock,
                Paperback = book.Paperback,
                Audio = book.Audio,
                Minutes = book.Minutes,
                Ebook = book.Ebook,
                YearPublished = book.YearPublished 
            };

            return View(inputBook);
        }


        [HttpPost]
        public IActionResult ChangeBook(InputBookModel book)
        {
            if(ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
            }
            return RedirectToAction("ChangeBook");
        }

        public IActionResult RemoveBook(int id)
        {
            //Spurja aftur hvort notandi vilji fjarlægja bók
            _bookService.RemoveBook(id);
            return RedirectToAction("Books");
        }

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
