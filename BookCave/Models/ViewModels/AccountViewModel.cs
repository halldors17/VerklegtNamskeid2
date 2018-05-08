using System.ComponentModel.DataAnnotations;
using BookCave.Models.ViewModels;

namespace BookCave.Models.ViewModels
{
    public class AccountViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public ShippingInfoViewModel Shipping { get; set; }
    }
}