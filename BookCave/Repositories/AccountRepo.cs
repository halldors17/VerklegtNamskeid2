using System.Collections.Generic;
using BookCave.Data;
using System.Linq;
using BookCave.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class AccountRepo
    {
        private DataContext _db;
        public AccountRepo()
        {
            _db = new DataContext();
        }
        public void AddShippingInfo(ShippingInfo shipping)
        {
            _db.AddRange(shipping);
            _db.SaveChanges();
        }
        public ShippingInfo GetShippingInfo(string Id)
        {
            var shipping = (from s in _db.ShippingInfo where s.UserId == Id select s).FirstOrDefault();
            return shipping;
        }
    }
}