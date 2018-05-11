using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class BookSalesInfoViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
}
}