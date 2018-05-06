using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class CategoryService
    {
        private CategoryRepo _categoryRepo;
        
        public CategoryService()
        {
            _categoryRepo = new CategoryRepo();
        }

        public List<CategoryListViewModel> GetAllCategories()
        {
            var categories = _categoryRepo.GetAllCategories();
            return categories;
        }

        public CategoryListViewModel GetCategory(int id)
        {
            var category = _categoryRepo.GetCategory(id);
            return category;
        }
    }
}