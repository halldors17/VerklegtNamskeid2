using System.Collections.Generic;
using BookCave.Data;
using BookCave.Models.ViewModels;
using System.Linq;
using BookCave.Models.EntityModels;

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
            //
            

            var category = (from c in _db.Categories
                    where c.Id == id
                    select new CategoryListViewModel 
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).SingleOrDefault();
            
            return category;
        }

        public CategoryDetailsViewModel GetCategoryDetails(int id)
        {
            var category = (from c in _db.Categories
                    join cId in _db.CategoryIdItem on c.Id equals cId.CategoryId
                    join b in _db.Books on cId.BookId equals b.Id
                    where c.Id == id
                    select new CategoryDetailsViewModel 
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Books = new List<BookListViewModel>
                        {
                            //foreach (var item in collection)
                            //{
                                new BookListViewModel 
                                {
                                    Id = b.Id,
                                    Title = b.Title,
                                    Price = b.Price,
                                    Image = b.Image
                                }
                            //}
                        }
                    }).First();
            return category;
        }
    }
}