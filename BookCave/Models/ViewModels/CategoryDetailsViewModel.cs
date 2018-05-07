using System.Collections.Generic;
using BookCave.Models.ViewModels;

namespace BookCave.Models.ViewModels
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookListViewModel> Books { get; set; }
    }
}