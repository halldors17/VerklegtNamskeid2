namespace BookCave.Models.ViewModels
{
    public class ShippingInfoViewModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string SendingMethod { get; set; }
    }
}