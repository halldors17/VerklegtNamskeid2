using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.ViewModels;

namespace BookCave.Models.ViewModels
{
    public class AccountViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public ShippingInfoViewModel Shipping { get; set; }
        public List<CartViewModel> Cart { get; set; }


    }
}