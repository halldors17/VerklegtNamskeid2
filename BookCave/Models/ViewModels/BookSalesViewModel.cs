using System.ComponentModel.DataAnnotations;

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
    }
}