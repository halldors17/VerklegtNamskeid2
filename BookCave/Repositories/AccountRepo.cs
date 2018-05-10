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
                Country = s.Country,
                SendingMethod = s.SendingMethod
            }).FirstOrDefault();
            return shipping;
        }
        public void AddShippingInfo(ShippingInfoInputModel shipping, string userId)
        {
            var user = GetShippingInfo(userId);
            if(user != null)
            {
                shipping.Id = user.Id;
                UpdateShippingInfo(shipping, userId);
            }
            else
            {
                var newShipping = new ShippingInfo
                {
                    UserId = userId,
                    Street = shipping.Street,
                    City = shipping.City,
                    PostalCode = shipping.PostalCode,
                    Country = shipping.Country,
                    SendingMethod = shipping.SendingMethod
                };
                _db.ShippingInfo.Add(newShipping);
                _db.SaveChanges();
            }
        }
        public void UpdateShippingInfo(ShippingInfoInputModel shipping, string userId)
        {
            var newShipping = _db.ShippingInfo.Find(shipping.Id);
            newShipping.PostalCode = shipping.PostalCode;
            newShipping.Street = shipping.Street;
            newShipping.City = shipping.City;
            newShipping.Country = shipping.Country;
            newShipping.SendingMethod = shipping.SendingMethod;

            _db.SaveChanges();
        }

        public void AddComment(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
        }

        public List<OrderListViewModel> GetOrdersForUser(string userId)
        {
            var ordersFromDb = _db.Orders.Where(u => u.CustomerId == userId).ToList();

            var orders = (from order in ordersFromDb
                        select new OrderListViewModel
                        {
                            Id = order.Id,
                            CustomerId = order.CustomerId,
                            PaidDate = order.PaidDate,
                            Status = order.Status,
                            Total = order.Total
                        }).ToList();

            return orders;
        }

        public void AddOrder(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
        }

        public OrderDetailViewModel GetOrder(int orderId)
        {
            var orderItems = _db.OrderItem.Where(o => o.OrderId == orderId).ToList();
            var order = _db.Orders.Find(orderId);

            var orderDetail = new OrderDetailViewModel
            {
                Id = order.Id,
                Total = order.Total,
                PaidDate = order.PaidDate,
                CustomerId = order.CustomerId,
                OrderItems = orderItems
            };

            return orderDetail;
        }

        public bool CheckCartItem(int bookId, string userId)
        {
            var item = (from c in _db.Cart
                        where c.CustomerId == userId && c.BookId == bookId
                        select c).ToList();
            
            if(item.Count == 0)
            {
                return false;
            }
            return true;
        }

        public void UpdateQuantity(int bookId, string userId)
        {
            /*
            var item = (from c in _db.Cart
                        where c.UserId == userId && c.BookId == bookId
                        select c).FirstOrDefault();
            */
            
            var bookFromDb = _db.Books.Find(bookId);
            var cartFromDb = _db.Cart.Where(b => b.BookId == bookFromDb.Id).FirstOrDefault();
            cartFromDb.Quantity++;
            _db.SaveChanges();
        }

        public void AddToCart(Cart cart)
        {
            _db.Cart.Add(cart);
            _db.SaveChanges();
        }
        public List<CartViewModel> GetCart(string userId)
        {
            var cart = (from a in _db.Cart
                    join b in _db.Books on a.BookId equals b.Id
                    where a.CustomerId == userId
                    select new CartViewModel
                    {
                        UserId = a.CustomerId,
                        BookId = b.Id,
                        Title = b.Title,
                        Image = b.Image,
                        Price = b.Price,
                        Discount = b.Discount,
                        Quantity = a.Quantity
                    }).ToList();

            return cart;
        }
    }
}