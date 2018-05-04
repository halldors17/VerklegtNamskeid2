using System.Collections.Generic;   

namespace BookCave.Models.EntityModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<AuthorIdItem> AuthorIdList { get; set; }
        public string Publisher { get; set; }
        public int YearPublished { get; set; }
        public int Price { get; set; }
        public List<LanguageItem> LanguageList { get; set; }
        public int Pages { get; set; }
        public int Minutes { get; set; }
        public bool Audio { get; set; }
        public bool Ebook { get; set; }
        public bool Paperback { get; set; }
        public List<CategoryIdItem> CategoryIdList { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public double Rating { get; set; }
    }
}