using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;

namespace BookCave.Models.InputModels
{
    public class InputOrderModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string SendingMethod { get; set; }
        //public ShippingInfo ShippingInfo { get; set; }
        //public int CustomerId { get; set; }
        //public List<OrderItem> OrderItems { get; set; }
        //public int Price { get; set; }
    }
}