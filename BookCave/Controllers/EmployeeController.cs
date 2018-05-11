using Microsoft.AspNetCore.Mvc;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using BookCave.Models.InputModels;
using BookCave.Models.EntityModels;
using BookCave.Models.ViewModels;
using System;

namespace BookCave.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private EmployeeService _employeeService;
        private BookService _bookService;
        private CategoryService _categoryService;
        private AuthorService _authorService;

        public EmployeeController() 
        {
            _bookService = new BookService();
            _employeeService = new EmployeeService();
            _categoryService = new CategoryService();
            _authorService = new AuthorService();

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
            var authors = _authorService.GetAllAuthors();
            return View(authors);
        }
         [HttpGet]
        public IActionResult AddAuthor()
        {
            ViewBag.Title = "Innranet höfundar";
            return View();
        }
        [HttpPost]
        public IActionResult AddAuthor(AuthorInputModel author)
        {
            if(ModelState.IsValid)
            {
                _authorService.AddAuthor(author);
            }

            return RedirectToAction("AddAuthor");
        }
        [HttpGet]
        public IActionResult ChangeAuthor(int id)
        {
            var author = _authorService.GetDetailsAuthor(id);

            var inputAuthor = new AuthorInputModel 
            {
                Name = author.Name,
                Description = author.Description,
                Image = author.AImage
            };
            return View(inputAuthor);
        }
        [HttpPost]
        public IActionResult ChangeAuthor(AuthorInputModel author)
        {
            if(ModelState.IsValid)
            {
                _authorService.UpdateAuthor(author);
            }
            return RedirectToAction("ChangeAuthor");
        }
        public IActionResult RemoveAuthor(int id)
        {
            //Spurja aftur hvort notandi vilji fjarlægja bók
            _authorService.RemoveAuthor(id);
            return RedirectToAction("Books");
        }


        public IActionResult Categories()
        {
            ViewBag.Title = "Innranet flokkar";
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        public IActionResult SalesBook(int id)
        {
            ViewBag.TotalPrice = _bookService.GetTotalForBookSales(id);
            ViewBag.TotalAmount = _bookService.GetTotalQuantityForBook(id);
            var salesBook = _bookService.GetSalesForBook(id);
            if(salesBook == null)
            {
                RedirectToAction("Books");
            }
            ViewBag.Title = "Innranet sala";
            return View(salesBook);
        }

       public IActionResult SalesAuthor(int id)
        {
            ViewBag.TotalPrice = _bookService.GetTotalSalesForAuthor(id);
            ViewBag.TotalAmount = _bookService.GetTotalAmountForAuthor(id);
            var salesAuthor = _authorService.GetSalesForAuthor(id);
            if(salesAuthor == null)
            {
                RedirectToAction("Authors");
            }
            ViewBag.Title = "Innranet sala";
            return View(salesAuthor);
        }
        public IActionResult Sales()
        {
            ViewBag.TotalPrice = _bookService.GetAllBookSales();
            ViewBag.TotalAmount = _bookService.GetAmountAllBooks();
            return View();
        }

        [HttpGet]
        public IActionResult ChangeCategory(int id)
        {
            var category = _categoryService.GetCategory(id);

            var inputCategory = new InputCategoryModel 
            {
                Name = category.Name,
                Id = category.Id
            };

            return View(inputCategory);
        }

        [HttpPost]
        public IActionResult ChangeCategory(InputCategoryModel category)
        {
            if(ModelState.IsValid)
            {
                _categoryService.UpdateCategory(category);
            }
            return RedirectToAction("ChangeCategory");
        }

        public IActionResult RemoveCategory(int id)
        {
            _categoryService.RemoveCategory(id);
            return RedirectToAction("Categories");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            ViewBag.Title = "Innranet bækur";
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(InputCategoryModel category)
        {
            if(ModelState.IsValid)
            {
                _categoryService.AddCategory(category);
            }

            return RedirectToAction("AddCategory");
        }
    }
}
