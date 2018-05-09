using System;
using System.Collections.Generic;
using BookCave.Data;
using System.Linq;
using BookCave.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;

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
        public List<BookListViewModel> GetAllBooksAlpha()
        {
            var books = (from b in _db.Books
            orderby b.Title ascending
            select new BookListViewModel
            {
                Id = b.Id,
                Image = b.Image,
                Title =b.Title,
                Price = b.Price
            }).ToList();
            return books;
        }
         public List<BookListViewModel> GetAllBooksLH()
        {
            var books = (from b in _db.Books
            orderby b.Price ascending
            select new BookListViewModel
            {
                Id = b.Id,
                Image = b.Image,
                Title =b.Title,
                Price = b.Price
            }).ToList();
            return books;
        }
          public List<BookListViewModel> GetAllBooksHL()
        {
            var books = (from b in _db.Books
            orderby b.Price descending
            select new BookListViewModel
            {
                Id = b.Id,
                Image = b.Image,
                Title =b.Title,
                Price = b.Price
            }).ToList();
            return books;
        }
          public List<BookListViewModel> GetAllBooksEinkunn()
        {
            var books = (from b in _db.Books
            orderby b.Rating descending
            select new BookListViewModel
            {
                Id = b.Id,
                Image = b.Image,
                Title =b.Title,
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
                        Price = a.Price * (1-(a.Discount/100)),
                        Discount = a.Discount
                    }).ToList();
            return books;
        }

        public List<BookListViewModel> GetBooksByTitle(string SearchString)
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
                    join a in _db.Authors on bId.AuthorId equals a.Id
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

            var comments = (from b in _db.Books
                        join c in _db.Comments on b.Id equals c.BookId
                        where b.Id == id
                        select new Comment
                        {
                            Rating = c.Rating,
                            BookComment = c.BookComment
                        }).ToList();
          
            var book = (from a in _db.Books
                        where a.Id == id
                        select new BookDetailViewModel
                        {
                            Id = a.Id,
                            AuthorList = authors,
                            CategoryList = categories,
                            Title = a.Title,
                            Image = a.Image,
                            Price = a.Price,
                            Publisher = a.Publisher,
                            YearPublished = a.YearPublished,
                            Pages = a.Pages,
                            Description = a.Description,
                            Stock = a.Stock,
                            Paperback = a.Paperback,
                            Ebook = a.Ebook,
                            Audio = a.Audio,
                            Minutes = a.Minutes,
                            BookComments = comments,
                            Rating = a.Rating
                        }).First();

            return book;
        }

        public void AddBook(InputBookModel book)
        {
            var newBook = new Book
            {
                Title = book.Title,
                CategoryId = book.CategoryId,
                Image = book.Image,
                Price = book.Price,
                Publisher = book.Publisher,
                AuthorId = book.AuthorId,
                Rating = book.Rating,
                Pages = book.Pages,
                Description = book.Description,
                Stock = book.Stock,
                Paperback = book.Paperback,
                Audio = book.Audio,
                Minutes = book.Minutes,
                Ebook = book.Ebook,
                YearPublished = book.YearPublished 
            };
            _db.Books.Add(newBook);
            _db.SaveChanges();

            //sækja nýju bókina
            var bookFromDb = _db.Books.Find(newBook.Id);

            //Tengja höfund og bók samann
            var newBookAuthorItem = new BookIdItem
            {
                BookId = bookFromDb.Id,
                AuthorId = bookFromDb.AuthorId
            };
            _db.BookIdItem.Add(newBookAuthorItem);

            //Tengja flokk og bók saman
            var newBookCategoryItem = new CategoryIdItem
            {
                BookId = bookFromDb.Id,
                CategoryId = bookFromDb.CategoryId
            };
            _db.CategoryIdItem.Add(newBookCategoryItem);

            _db.SaveChanges();
        }

        public void UpdateBook(InputBookModel book)
        {
            var bookFromDb = _db.Books.Find(book.Id);

            bookFromDb.Title = book.Title;
            bookFromDb.CategoryId = book.CategoryId;
            bookFromDb.Image = book.Image;
            bookFromDb.Price = book.Price;
            bookFromDb.Publisher = book.Publisher;
            bookFromDb.AuthorId = book.AuthorId;
            bookFromDb.Rating = book.Rating;
            bookFromDb.Pages = book.Pages;
            bookFromDb.Description = book.Description;
            bookFromDb.Stock = book.Stock;
            bookFromDb.Paperback = book.Paperback;
            bookFromDb.Audio = book.Audio;
            bookFromDb.Minutes = book.Minutes;
            bookFromDb.Ebook = book.Ebook;
            bookFromDb.YearPublished = book.YearPublished;
            
            _db.SaveChanges();

            //Tengja höfund og bók samann
            var bookAuthorItemDb = _db.BookIdItem.Where(b => b.BookId == bookFromDb.Id).FirstOrDefault();
            bookAuthorItemDb.AuthorId = bookFromDb.AuthorId;

            //Tengja flokk og bók saman
            var bookCategoryItemDb = _db.CategoryIdItem.Where(b => b.BookId == bookFromDb.Id).FirstOrDefault();
            bookCategoryItemDb.CategoryId = bookFromDb.CategoryId;

            _db.SaveChanges();
        }

        public void RemoveBook(int id)
        {
            //Fjarlægja tenginu við höfunda
            var bookAuthorItemDb = _db.BookIdItem.Where(b => b.BookId == id).ToList();
            foreach(var ba in bookAuthorItemDb)
            {
                _db.BookIdItem.Remove(ba);
            }

            //Fjarlægjatenginu við flokka
            var bookCategoryItemDb = _db.CategoryIdItem.Where(b => b.BookId == id).ToList();
            foreach (var bc in bookCategoryItemDb)
            {
                _db.CategoryIdItem.Remove(bc);
            };

            //Fjarlægja bókina
            var bookFromDb = _db.Books.Find(id);
            _db.Books.Remove(bookFromDb);

            _db.SaveChanges();
        }
    }
}
