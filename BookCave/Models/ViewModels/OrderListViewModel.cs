using System;
using System.Collections.Generic;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ShippingInfo ShippingInfo { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public DateTime PaidDate { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}