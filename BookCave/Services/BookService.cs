using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class BookService
    {
        private BookRepo _bookRepo;
        
        public BookService()
        {
            _bookRepo = new BookRepo();
        }
        
        public List<BookListViewModel> GetAllBooks()
        {
            var books = _bookRepo.GetAllBooks();
            return books;
        }
        public List<BookListViewModel> GetAllBooksAlpha()
        {
            var books = _bookRepo.GetAllBooksAlpha();
            return books;
        }
          public List<BookListViewModel> GetAllBooksLH()
        {
            var books = _bookRepo.GetAllBooksLH();
            return books;
        }
          public List<BookListViewModel> GetAllBooksHL()
        {
            var books = _bookRepo.GetAllBooksHL();
            return books;
        }
        public List<BookListViewModel> GetAllBooksEinkunn()
        {
            var books = _bookRepo.GetAllBooksEinkunn();
            return books;
        }

        public List<BookListViewModel> GetTop10()
        {
            var books = _bookRepo.GetBooksByRating().Take(10).ToList();
            return books;
        }
        public List<BookListViewModel> GetDiscount()
        {
            var books = _bookRepo.GetDiscount();
            return books;
        }

        internal object GetBooksBySearch(string SearchBy, string SearchString)
        {    
            var books = _bookRepo.GetBooksBySearch(SearchBy, SearchString);
            if(books.Count == 0)
            {
                return 0;
            }
            return books;
        }
        public List<BookSalesViewModel> GetSalesBooksInfo()
        {
            var books = _bookRepo.GetSalesBooksInfo();
            return books;
        }

        public BookSalesInfoViewModel GetSalesForBook(int id)
        {
            var books = _bookRepo.GetSalesForBook(id);
            return books;
        }

        public BookDetailViewModel GetBookDetails(int Id)
        {
            var book = _bookRepo.GetBookDetails(Id);
            return book;
        }
        public void AddBook(InputBookModel book)
        {
            _bookRepo.AddBook(book);
        }

        public void UpdateBook(InputBookModel book)
        {
            _bookRepo.UpdateBook(book);
        }

        public void RemoveBook(int id)
        {
            _bookRepo.RemoveBook(id);
        }
        public double GetTotalForBookSales(int id)
        {
            return _bookRepo.GetTotalForBookSales(id);
        }
        public double GetTotalQuantityForBook(int id)
        {
            return _bookRepo.GetTotalQuantityForBook(id);
        }
        public double GetAllBookSales()
        {
            return _bookRepo.GetAllBookSales();
        }
        public double GetAmountAllBooks()
        {
            return _bookRepo.GetAmountAllBooks();
        }
         public double GetTotalSalesForAuthor(int id)
         {
             return _bookRepo.GetTotalSalesForAuthor(id);
         }
          public double GetTotalAmountForAuthor(int id)
          {
              return _bookRepo.GetTotalAmountForAuthor(id);
          }
    }

    }