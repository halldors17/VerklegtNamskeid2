using System.Collections.Generic;
using BookCave.Data;
using BookCave.Models.ViewModels;
using System.Linq;

namespace BookCave.Repositories
{
    public class CategoryRepo
    {
        private DataContext _db;
        public CategoryRepo()
        {
            _db = new DataContext();
        }
        
        public List<CategoryListViewModel> GetAllCategories()
        {
            var categories = (from c in _db.Categories
                    select new CategoryListViewModel {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();
            
            return categories;
        }

        public CategoryListViewModel GetCategory(int id)
        {
            var category = (from c in _db.Categories
                    where c.Id == id
                    select new CategoryListViewModel {
                        Id = c.Id,
                        Name = c.Name
                    }).SingleOrDefault();
            
            return category;
        }
    }
}