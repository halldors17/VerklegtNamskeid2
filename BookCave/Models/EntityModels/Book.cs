using System.Collections.Generic;   

namespace BookCave.Models.EntityModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<BookIdItem> AuthorBookIdList { get; set; }
        public string Publisher { get; set; }
        public int YearPublished { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }
        public List<CategoryIdItem> CategoryIdList { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Rating { get; set; }
        public int Discount { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set;}
    }
}