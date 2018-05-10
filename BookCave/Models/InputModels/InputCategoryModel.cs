using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class InputCategoryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}