using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;

namespace BookCave.Models.InputModels
 {
    public class InputBookModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage="Nauðsynlegt að fylla út Titill")]
        public string Title { get; set; }
        [Required (ErrorMessage="Nauðsynlegt að fylla út Útgefandi")]
        public string Publisher { get; set; }
        [Required]
        public int YearPublished { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        public string Description { get; set; }
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