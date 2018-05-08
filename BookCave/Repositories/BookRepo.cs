using System.Collections.Generic;
using BookCave.Data;
using System.Linq;
using BookCave.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.EntityModels;

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
        public List<BookListViewModel> GetDiscount()
        {
            var books = (from a in _db.Books
                    where a.Discount > 0
                    select new BookListViewModel
                    {
                        Id = a.Id,
                        Image = a.Image,
                        Title = a.Title,
                        Price = a.Price,
                        Discount = a.Discount
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

        public List<BookSalesViewModel> GetSalesBooksInfo()
        {
            var books = (from b in _db.Books 
                    join bId in _db.BookIdItem on b.Id equals bId.BookId
                    join a in _db.Authors on b.Id equals a.Id
                    select new BookSalesViewModel 
                    {
                        Id = b.Id,
                        Image = b.Image,
                        Title = b.Title,
                        Publisher = b.Publisher,
                        Author = a.Name
                    }).ToList();
            
            return books;
        }

        public BookDetailViewModel GetBookDetails(int id)
        {
            //var tempbooks = _db.Books.Include(i => i.Authors).ToList(); eftir Patrek
            var authors = (from b in _db.Books
                        join bId in _db.BookIdItem on b.Id equals bId.BookId
                        join a in _db.Authors on bId.AuthorId equals a.Id
                        where b.Id == id
                        select new Author
                        {
                            Id = a.Id,
                            Name = a.Name
                        }).ToList();

            var categories = (from b in _db.Books
                        join cId in _db.CategoryIdItem on b.Id equals cId.BookId
                        join c in _db.Categories on cId.CategoryId equals c.Id
                        where b.Id == id
                        select new Category
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).ToList();
            
            var book = (from a in _db.Books
                        where a.Id == id
                        select new BookDetailViewModel
                        {
                            AuthorList = authors,
                            CategoryList = categories,
                            Title = a.Title,
                            Image = a.Image,
                            Price = a.Price,
                            Publisher = a.Publisher,
                            //Author = b.Name,
                            YearPublished = a.YearPublished,
                            Pages = a.Pages,
                            Description = a.Description,
                            //Category = c.Name,
                            //Rating = a.Rating,
                            Stock = a.Stock,
                            Paperback = a.Paperback,
                            Ebook = a.Ebook,
                            Audio = a.Audio,
                            Minutes = a.Minutes,

                        }).First();

            return book;
        }
    //----GAMLA BOOK DETAILS----
       /* public List <BookDetailViewModel> GetBookDetails(int id)
        {
            //var tempbooks = _db.Books.Include(i => i.Authors).ToList(); eftir Patrek

            var books = (from a in _db.Books
                        join b in _db.BookIdItem on a.Id equals b.BookId into tempbook
                        join c in _db.CategoryIdItem on a.Id equals c.CategoryId
                        join d in _db.Authors on b.Id equals d.Id
                        join e in _db.Categories on c.CategoryId equals e.Id
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
                            Category = e.Name,
                            //Rating = a.Rating,
                            Stock = a.Stock,
                            Paperback = a.Paperback,
                            Ebook = a.Ebook,
                            Audio = a.Audio,
                            Minutes = a.Minutes,

                        }).ToList();

            return books;
        }
        
        public BookDetailViewModel GetSalesBook(int id)
        {
            var books = (from a in _db.Books
            join b in _db.BookIdItem on a.Id equals b.BookId
            join c in _db.CategoryIdItem on a.Id equals c.CategoryId
            join d in _db.Authors on b.Id equals d.Id
            join e in _db.Categories on c.CategoryId equals e.Id
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
                Category = e.Name,
                //Rating = a.Rating,
                Stock = a.Stock,
                Paperback = a.Paperback,
                Ebook = a.Ebook,
                Audio = a.Audio,
                Minutes = a.Minutes,

            }).First();

            return books;
        }*/

        public void AddBook(InputBookModel book)
        {
            //gæti verið bý höfundur
            //category id

            var newBook = (from a in _db.Books
                        join b in _db.Authors on a.AuthorId equals b.Id
                        join c in _db.Categories on a.CategoryId equals c.Id
                        where a.Id == book.Id
                        select new Book
                        {
                            Title = book.Title,
                            Image = book.Image,
                            Price = book.Price,
                            Publisher = book.Publisher,
                            AuthorId = b.Id,
                            YearPublished = book.YearPublished,
                            Pages = book.Pages,
                            Description = book.Description,
                            CategoryId = c.Id,
                            //Rating = a.Rating,
                            Stock = book.Stock,
                            Paperback = book.Paperback,
                            Ebook = book.Ebook,
                            Audio = book.Audio,
                            Minutes = book.Minutes
                        }).ToList(); //??
            //??
            _db.AddRange(newBook);
            _db.SaveChanges();
        }

    }
}
