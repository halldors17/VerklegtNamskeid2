using System;
using Microsoft.AspNetCore.Http;

namespace BookCave.Models.ViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
    }
}