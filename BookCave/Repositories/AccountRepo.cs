using System.Collections.Generic;
using BookCave.Data;
using System.Linq;
using BookCave.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;

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
        public ShippingInfoViewModel GetShippingInfo(string Id)
        {
            var shipping = (from s in _db.ShippingInfo where s.UserId == Id select 
            new ShippingInfoViewModel
            {
                Id = s.Id,
                Street = s.Street,
                City = s.City,
                PostalCode = s.PostalCode,
                Country = s.Country
            }).FirstOrDefault();
            return shipping;
        }
        public void AddShippingInfo(ShippingInfoInputModel shipping, string userId)
        {
           // var newShipping = 
        }
    }
}