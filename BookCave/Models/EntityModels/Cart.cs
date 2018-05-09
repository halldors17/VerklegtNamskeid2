using System;
using Microsoft.AspNetCore.Http;

namespace BookCave.Models.EntityModels
{
    public class Cart
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
      
    }
}