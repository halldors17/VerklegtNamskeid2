using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> BookIdList { get; set; }
    }
}