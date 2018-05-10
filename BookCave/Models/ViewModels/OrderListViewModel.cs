using System;
using System.Collections.Generic;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime PaidDate { get; set; }
        public string Status { get; set; }
        public double Total { get; set; }
    }
}