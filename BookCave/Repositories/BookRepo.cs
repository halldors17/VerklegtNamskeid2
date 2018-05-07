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
            var books = (from b in _db.Books 
                    select new BookListViewModel 
                    {
                        Id = b.Id,
                        Image = b.Image,
                        Title = b.Title,
                        Price = b.Price
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

        public List<BookSalesViewModel> GetSalesBooks()
        {
            var books = (from b in _db.Books 
                    //join
                    select new BookSalesViewModel 
                    {
                        Id = b.Id,
                        Image = b.Image,
                        Title = b.Title,
                        Publisher = b.Publisher,
                        //Author = 
                    }).ToList();
            
            return books;
        }

        public List <BookDetailViewModel> GetBookDetails(int id)
        {
            var books = (from a in _db.Books
            join b in _db.BookIdItem on a.Id equals b.BookId
            join d in _db.Authors on b.Id equals d.Id
            where a.Id == id
            select new BookDetailViewModel
            {
                Title = a.Title,
                Image = a.Image,
                Price = a.Price,
                Publisher = a.Publisher,
                Author = d.Name,
                YearPublished = a.YearPublished,
                Pages = a.Pages,
                Description = a.Description,
            }).ToList();

            return books;
        }
    }
}