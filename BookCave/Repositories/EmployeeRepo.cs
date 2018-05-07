using System.Collections.Generic;
using BookCave.Data;
using System.Linq;

namespace BookCave.Repositories
{
    public class EmployeeRepo
    {
        private DataContext _db;
        
        public EmployeeRepo()
        {
            _db = new DataContext();
        }
    }
}