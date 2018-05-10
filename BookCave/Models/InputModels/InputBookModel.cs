using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;

namespace BookCave.Models.InputModels
 {
    public class InputBookModel
    {
        public int Id { get; set; }
        [Required, Display(Name = "Titill")]
        public string Title { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public int YearPublished { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        public int Minutes { get; set; }
        
        public bool Audio { get; set; }
        public bool Ebook { get; set; }
        public bool Paperback { get; set; }

        [Required]
        public string Description { get; set; }
        public int Stock { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public int AuthorId { get; set ; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int Discount { get; set; }

        public List<Author> AuthorList { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}