namespace BookCave.Models.EntityModels
{
    public class Comment
    {
        public int Id { get; set; }
        public string BookComment { get; set; }
        public double Rating { get; set; }
        public int BookId { get; set; }
        public int AccountId { get; set; }
    }
}