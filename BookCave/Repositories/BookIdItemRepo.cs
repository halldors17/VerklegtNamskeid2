using System.Collections.Generic;
using BookCave.Data;
using System.Linq;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class BookIdItemRepo
    {
        private DataContext _db;
        public BookIdItemRepo()
        {
            _db = new DataContext();
        }
    }
}