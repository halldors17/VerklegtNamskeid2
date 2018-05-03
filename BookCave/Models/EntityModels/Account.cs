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
        public string image { get; set; }
        public List<int> Cart { get; set; }
        public List<int> FavoriteBooks { get; set; }
        public List<int> WishList { get; set; }
        public OrderItem history { get; set; }
    } 
}