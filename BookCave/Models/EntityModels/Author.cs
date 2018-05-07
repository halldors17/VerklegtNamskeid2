using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<BookIdItem> BookIdList { get; set; }
        public string Image { get; set; }

        //public virtual ICollection<Book> Books { get; set; } Eftir Patrek

    }
}