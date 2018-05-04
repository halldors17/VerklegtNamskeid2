using System.Collections.Generic;
using BookCave.Data;
using System.Linq;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        private DataContext _db;
        public BookRepo()
        {
            _db = new DataContext();
        }
        
        public List<BookListViewModel> GetAllBooks()
        {
            var books = (from a in _db.Books 
                    select new BookListViewModel {
                        Title = a.Title,
                    }).ToList();
            
            return books;
        }

    }
}