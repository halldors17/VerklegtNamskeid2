using System.Linq;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryService _categorieService;

        public CategoryController() 
        {
            _categorieService = new CategoryService();
        }

        public IActionResult Index()
        {
            var categories = _categorieService.GetAllCategories();
            return View(categories);
        }

        public IActionResult Details(int id)
        {
            var result = _categorieService.GetCategoryDetails(id);

            if(result == null)
            {
                return View("NotFound");
            }
            else{
                return View(result);
            }
        }
    }
}