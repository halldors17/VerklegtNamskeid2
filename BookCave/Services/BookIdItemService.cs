using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class BookIdItemService
    {
        private BookIdItemRepo _bookIdItemRepo;
        public BookIdItemService()
        {
            _bookIdItemRepo = new BookIdItemRepo();
        }
    }
}