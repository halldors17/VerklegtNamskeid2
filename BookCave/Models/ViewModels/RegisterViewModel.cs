using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "Notendanafn")]
        public string Username { get; set; }
        [Required, Display(Name = "Fullt nafn")]
        public string FullName { get; set; }
       [Required, EmailAddress, Display(Name = "Netfang")]
        public string Email { get; set; }
        [Required, MinLength(8), DataType(DataType.Password), Display(Name = "Lykilorð")]
        public string Password { get; set; }
        [Required, MinLength(8), DataType(DataType.Password), Display(Name = "Staðfesta Lykilorð")]
        [Compare("Password", ErrorMessage = "Lykilorðið passar ekki")]
        public string ConfirmPassword { get; set; }
    }
}