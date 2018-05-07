 namespace BookCave.Models.ViewModels
 {
 public class BookDetailsViewModel
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
        public string Author { get; set; }
        public string Category { get; set; }
    }
}