using System.Collections.Generic;
using BookCave.Data;
using BookCave.Models.ViewModels;
using System.Linq;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using System;

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
                    select new CategoryListViewModel 
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();
            
            return categories;
        }

        public CategoryListViewModel GetCategory(int id)
        {
            var category = (from c in _db.Categories
                    where c.Id == id
                    select new CategoryListViewModel 
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).SingleOrDefault();
            
            return category;
        }

        public void RemoveCategory(int id)
        {
            //Fjarlægja tenginu bóka við flokkinn
            var bookCategoryItemDb = _db.CategoryIdItem.Where(c => c.CategoryId == id).ToList();
            foreach (var bc in bookCategoryItemDb)
            {
                _db.CategoryIdItem.Remove(bc);
            };

            //Fjarlægja flokkinn
            var categoryFromDb = _db.Categories.Find(id);
            _db.Categories.Remove(categoryFromDb);

            _db.SaveChanges();
        }

        public List<BookListViewModel> GetCategoryDetails(int id)
        {
            var books = (from c in _db.Categories
                    join cId in _db.CategoryIdItem on c.Id equals cId.CategoryId
                    join b in _db.Books on cId.BookId equals b.Id
                    where c.Id == id
                    select new BookListViewModel
                    {
                            Id = b.Id,
                            Title = b.Title,
                            Price = b.Price,
                            Image = b.Image
                    }).ToList();
            return books;
        }

        public void UpdateCategory(InputCategoryModel category)
        {
            var categoryFromDb = _db.Categories.Find(category.Id);

            categoryFromDb.Name = category.Name;

            _db.SaveChanges();
        }

        public void AddCategory(InputCategoryModel category)
        {
            var newCategory = new Category
            {
                Id = category.Id,
                Name = category.Name
            };
            _db.Categories.Add(newCategory);
            _db.SaveChanges();
        }
    }
}