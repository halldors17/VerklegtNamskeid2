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
        public List<AuthorDetailsViewModel> GetDetailsAuthor()
        {
            var authors = (from a in _db.Authors 
            join b in _db.BookIdItem on a.Id equals b.Id
            join c in _db.Books on b.BookId equals c.Id
            select new AuthorDetailsViewModel
            {
                Name = a.Name,
                Description = a.Description,
                AImage = a.Image,
                Title = c.Title,
                BImage = c.Image
            }).ToList();
            return authors;
        }

    }
}