namespace BookCave.Models.EntityModels
{
    public class ShippingInfo
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
    }
}