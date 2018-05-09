using System;
using System.Collections.Generic;
using BookCave.Models.InputModels;
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

        public List<BookListViewModel> GetCategoryDetails(int id)
        {
            var category = _categoryRepo.GetCategoryDetails(id);
            return category;
        }

        public void UpdateCategory(InputCategoryModel category)
        {
            _categoryRepo.UpdateCategory(category);
        }

        public void RemoveCategory(int id)
        {
            _categoryRepo.RemoveCategory(id);
        }

        public void AddCategory(InputCategoryModel category)
        {
            _categoryRepo.AddCategory(category);
        }
    }
}