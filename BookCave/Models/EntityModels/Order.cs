using System;
using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int Total { get; set; }
        public DateTime PaidDate { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}