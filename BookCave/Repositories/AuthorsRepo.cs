using System.Collections.Generic;
using BookCave.Data;
using System.Linq;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class AuthorRepo
    {
        private DataContext _db;
        public AuthorRepo()
        {
            _db = new DataContext();
        }
        
        public List<AuthorListViewModel> GetAllAuthors()
        {
            var authors = (from a in _db.Authors 
                    select new AuthorListViewModel 
                    {
                        Name = a.Name,
                        
                    }).ToList();
            
            return authors;
        }
        public List<AuthorDetailsViewModel> GetDetailsAuthor(int id)
        {
            var books = (from a in _db.Authors
                    join bId in _db.BookIdItem on a.Id equals bId.AuthorId
                    join b in _db.Books on bId.BookId equals b.Id
                    where a.Id == id
                    select new BookListViewModel
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Image = b.Image,
                        Price = b.Price
                    }).ToList();

            var authors = (from a in _db.Authors 
                    where a.Id == id
                    select new AuthorDetailsViewModel
                    {
                        Name = a.Name,
                        Description = a.Description,
                        AImage = a.Image,
                        BookList = books
                    }).ToList();
            return authors;
        }

    }
}