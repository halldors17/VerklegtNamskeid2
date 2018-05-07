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

        internal object GetBooksBySearch(string SearchString)
        {
            var books = _bookRepo.GetBooksBySearch(SearchString).ToList();
            return books;
        }


        public List<BookSalesViewModel> GetSalesBooks()
        {
            var books = _bookRepo.GetSalesBooks();
            return books;
        }

        public List<BookDetailViewModel> GetBookDetails(int id)
        {
            var books = _bookRepo.GetBookDetails(id);
            return books;
        }
    }
}