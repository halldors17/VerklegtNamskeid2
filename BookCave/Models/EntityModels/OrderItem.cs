namespace BookCave.Models.EntityModels
{
    public class OrderItem
    {
         public int Id { get; set; }
         public int OrderId { get; set; }
         public int BookId { get; set; }
         public int AuthorId { get; set; }
         public int Quantity { get; set; }
         public double Price { get; set; }
         public string Title { get; set; }
    }
}