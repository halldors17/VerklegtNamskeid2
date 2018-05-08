using System;
using System.Collections.Generic;
using System.Linq;
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

        internal object GetBooksBySearch(string SearchString)
        {
            var books = _bookRepo.GetBooksBySearch(SearchString).ToList();
            return books;
        }

        public List<BookSalesViewModel> GetSalesBooksInfo()
        {
            var books = _bookRepo.GetSalesBooksInfo();
            return books;
        }
/*
        public BookDetailViewModel GetSalesBooks(int id)
        {
            var books = _bookRepo.GetSalesBook(id);
            return books;
        }
*/
        public BookDetailViewModel GetBookDetails(int id)
        {
            var book = _bookRepo.GetBookDetails(id);
            return book;
        }
        

        public void AddBook(InputBookModel book)
        {
            _bookRepo.AddBook(book);
        }

    }
}