using System.Collections.Generic;   

namespace BookCave.Models.EntityModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<int> AuthorId { get; set; }
        public string Publisher { get; set; }
        public int YearPublished { get; set; }
        public int Price { get; set; }
        public List<string> LanguageList { get; set; }
        public int Pages { get; set; }
        public int Minutes { get; set; }
        public bool Audio { get; set; }
        public bool Ebook { get; set; }
        public bool Paperback { get; set; }
        public List<int> CategoryId { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
    }
}