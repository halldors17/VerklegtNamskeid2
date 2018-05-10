using System;
using System.Collections.Generic;
using BookCave.Models.EntityModels;

namespace BookCave.Models.InputModels
{
    public class InputOrderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string SendingMethod { get; set; }
        //public ShippingInfo ShippingInfo { get; set; }
        //public int CustomerId { get; set; }
        //public List<OrderItem> OrderItems { get; set; }
        //public int Price { get; set; }
    }
}