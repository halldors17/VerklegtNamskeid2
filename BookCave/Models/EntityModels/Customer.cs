namespace BookCave.Models.EntityModels
{
    public class Customer
    {
        //Vantar ShippingInfo til að klára
        //public ShippingInfo Shipping { get; set; }

        public OrderItem Cart { get; set; }
    }
}