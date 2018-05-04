using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ShippingInfo Shipping { get; set; }
        public string Image { get; set; }
        public List<BookIdItem> Cart { get; set; }
        public List<BookIdItem> FavoriteBooks { get; set; }
        public List<BookIdItem> WishList { get; set; }
        public List<OrderItem> History { get; set; }
    } 
}