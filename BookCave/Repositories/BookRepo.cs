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
                    select new BookListViewModel 
                    {
                        Id = a.Id,
                        Image = a.Image,
                        Title = a.Title,
                        Price = a.Price
                    }).ToList();
            
            return books;
        }

        public List<BookListViewModel> GetBooksByRating()
        {
            var books = (from b in _db.Books
                    orderby b.Rating descending
                    select new BookListViewModel 
                    {
                        Id = b.Id,
                        Image = b.Image,
                        Title = b.Title,
                        Price = b.Price,
                    }).ToList();
            
            return books;
        }

        public List<BookListViewModel> GetBooksBySearch(string SearchString)
        {
            var books = (from b in _db.Books
                    orderby b.Title ascending
                    where b.Title.Contains(SearchString)
                    select new BookListViewModel 
                    {
                        Id = b.Id,
                        Image = b.Image,
                        Title = b.Title,
                        Price = b.Price,
                    }).ToList();
            
            return books;
        }
    }
}