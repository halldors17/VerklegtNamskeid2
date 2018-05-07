using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class BookSalesViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Image { get; set; }
        
        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public List<CategoryListViewModel> Categories { get; set; }
    }
}