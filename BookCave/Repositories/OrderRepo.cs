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
        
        public List<OrderListViewModel> GetAllOrders()
        {
            var orders = (from b in _db.Orders 
                    select new OrderListViewModel 
                    {
                        
                    }).ToList();
            
            return orders;
        }

    }
}