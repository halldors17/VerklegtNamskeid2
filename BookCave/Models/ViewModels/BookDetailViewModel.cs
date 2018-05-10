using System.Collections.Generic;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
 {
 public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int YearPublished { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
        public int Minutes { get; set; }
        public bool Audio { get; set; }
        public bool Ebook { get; set; }
        public bool Paperback { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public double Rating { get; set; }
        public double UserAvgRating { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Discount { get; set; }
        public List<Author> AuthorList { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Comment> BookComments { get; set; }
    }
}