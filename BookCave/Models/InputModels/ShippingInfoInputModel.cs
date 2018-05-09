using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class ShippingInfoInputModel
    {
        public int Id { get; set; }
        [Required, Display(Name = "Heimilisfang")]
        public string Street { get; set; }
        [Required, Display(Name = "Borg")]
        public string City { get; set; }
        [Required, Range(100, 1000000000),  Display(Name = "Póstnúmer")]
        public int PostalCode { get; set; }
        [Required, Display(Name = "Land")]
        public string Country { get; set; }
        [Required, Display(Name = "Sendingarmáti")]
        public string SendingMethod { get; set; }
    }
}