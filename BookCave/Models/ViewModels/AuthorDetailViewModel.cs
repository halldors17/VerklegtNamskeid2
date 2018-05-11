using System.Collections.Generic;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
 {
     public class AuthorDetailsViewModel
     {
        public int AId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<BookListViewModel> BookList { get; set; }
        public string AImage { get; set; }
        public string BImage { get; set; }
     }
 }