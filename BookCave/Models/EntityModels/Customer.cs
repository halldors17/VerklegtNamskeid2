namespace BookCave.Models.EntityModels
{
    public class Customer
    {
        public ShippingInfo Shipping { get; set; }
        public OrderItem Cart { get; set; }
    }
}