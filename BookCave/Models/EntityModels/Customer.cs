namespace BookCave.Models.EntityModels
{
    public class Customer
    {
        public int Id { get; set; }
        public ShippingInfo Shipping { get; set; }
        public OrderItem Cart { get; set; }
    }
}