using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class InputCommentModel
    {
        [Required, Display(Name = "Umsögn")]
        public string BookComment { get; set; }
        [Required, Range(0, 10), Display(Name = "Einkunn")]
        public double Rating { get; set; }
        public int BookId { get; set; }
    }
}