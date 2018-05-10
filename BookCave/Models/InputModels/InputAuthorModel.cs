using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class AuthorInputModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }

    }
}