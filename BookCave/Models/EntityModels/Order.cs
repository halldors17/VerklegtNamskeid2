using System;
using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public double Total { get; set; }
        public DateTime PaidDate { get; set; }
        public string CustomerId { get; set; }
        public int ShippingInfoId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}