using System;

namespace BookCave.Models.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ShippingInfo ShippingInfo { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public DateTime PaidDate { get; set; }
        public int CustomerId { get; set; }
        public OrderItem OrderItem { get; set;}
    }
}