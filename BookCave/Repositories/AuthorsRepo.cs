using System.Collections.Generic;
using BookCave.Data;
using System.Linq;
using BookCave.Models.ViewModels;
using BookCave.Models.InputModels;
using BookCave.Models.EntityModels;

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
                        Id = a.Id,
                        Name = a.Name,
                        Image = a.Image
                        
                    }).ToList();
            
            return authors;
        }

        public List<AuthorListViewModel> GetAuthorsByName(string SearchString)
        {
            var authors = (from a in _db.Authors
                    where a.Name.Contains(SearchString)
                    select new AuthorListViewModel 
                    {
                        Name = a.Name
                    }).ToList();
            
            return authors;
        }

        public AuthorDetailsViewModel GetDetailsAuthor(int id)
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
                    }).FirstOrDefault();
            return authors;
        }
        public void AddAuthor(AuthorInputModel author)
        {
            var newAuthor = new Author
            {
                Name = author.Name,
                Description = author.Description,
                Image = author.Image
            };
            _db.Authors.Add(newAuthor);
            _db.SaveChanges();
        }
        public void UpdateAuthor(AuthorInputModel author)
        {
            var authorFromDb = _db.Authors.Find(author.Id);

            authorFromDb.Name = author.Name;
            authorFromDb.Description = author.Description;
            authorFromDb.Image = author.Image;
            
            _db.SaveChanges();
        }
        public List<AuthorInfoViewModel> GetAuthorInfo()
        {
            var authors = (from b in _db.Authors 
                    join bId in _db.BookIdItem on b.Id equals bId.AuthorId
                    join a in _db.Books on bId.BookId equals a.Id
                    select new AuthorInfoViewModel 
                    {
                        Id = b.Id,
                        Image = b.Image,
                        Name = b.Name,
                        Description = b.Description,
                    }).ToList();

            return authors;
        }
         public void RemoveAuthor(int id)
        {
            //Fjarlægja bækur
            var booksByAuthorDb = _db.Books.Where(b => b.AuthorId == id).ToList();
            foreach(var b in booksByAuthorDb)
            {
                _db.Books.Remove(b);
            }

            //Fjarlægja tenginu við bækur
            var authorBookItemDb = _db.BookIdItem.Where(b => b.AuthorId == id).ToList();
            foreach(var ba in authorBookItemDb)
            {
                _db.BookIdItem.Remove(ba);
            }
            //Fjarlægja höfundinn
            var authorFromDb = _db.Authors.Find(id);
            _db.Authors.Remove(authorFromDb);

            _db.SaveChanges();
        }
        public AuthorSalesInfoViewModel GetSalesForAuthor(int id)
        { 
           var books = (from a in _db.Authors
                    join bId in _db.BookIdItem on a.Id equals bId.AuthorId
                    join b in _db.Books on bId.BookId equals b.Id
                    where a.Id == id
                    select new BookSalesInfoViewModel
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Image = b.Image,
                        Price = b.Price
                    }).ToList();

            var authors = (from a in _db.Authors 
                    where a.Id == id
                    select new AuthorSalesInfoViewModel
                    {
                        Name = a.Name,
                        Image = a.Image,
                        BookList = books
                    }).FirstOrDefault();
            return authors;
            
        }
    }
}