using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class AccountViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public ShippingInfo Shipping { get; set; }
    }
}