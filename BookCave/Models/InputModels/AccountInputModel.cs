using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class AccountInputModel
    {
        [Required, Display(Name = "Eiginnafn")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Eftirnafn")]
        public string LastName { get; set; }
        [Required, EmailAddress, Display(Name = "Netfang")]
        public string Email { get; set; }
         [Range(1, 1000),  Display(Name = "Aldur")]
        public int Age { get; set; }
        [Required, Display(Name = "Mynd")]
        public string Image { get; set; }
        [Required, Display(Name = "Uppáhalds bók")]
        public string FavBook { get; set; }
    }
}