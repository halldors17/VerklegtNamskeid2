using System.Collections.Generic;
using BookCave.Data;
using System.Linq;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        private DataContext _db;
        
        public OrderRepo()
        {
            _db = new DataContext();
        }
        
        public List<OrderListViewModel> GetOrder(int id)
        {
            var orders = (from o in _db.Orders
                    join c in _db.Customers on o.Id equals c.Id
                    where id == c.Id
                    select new OrderListViewModel 
                    {
                        
                    }).ToList();
            
            return orders;
        }

    }
}