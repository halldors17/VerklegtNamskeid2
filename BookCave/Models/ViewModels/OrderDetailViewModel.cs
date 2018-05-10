using System;
using System.Collections.Generic;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public DateTime PaidDate { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}