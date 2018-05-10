using System.Collections.Generic;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class AccountService
    {
        private AccountRepo _accountRepo;
        public AccountService()
        {
            _accountRepo = new AccountRepo();
        }

        public ShippingInfoViewModel GetShippingInfo(string Id)
        {
            return _accountRepo.GetShippingInfo(Id);
        }
        public void AddShippingInfo(ShippingInfoInputModel shipping, string userId)
        {
            _accountRepo.AddShippingInfo(shipping, userId);
        }

        public void AddComment(Comment comment)
        {
            _accountRepo.AddComment(comment);
        }

        public List<OrderListViewModel> GetOrdersForUser(string userId)
        {
            return _accountRepo.GetOrdersForUser(userId);
        }

        public void AddOrder(Order order)
        {
            _accountRepo.AddOrder(order);
        }

        public OrderDetailViewModel GetOrder(int id)
        {
            return _accountRepo.GetOrder(id);
        }

        public bool CheckCartItem(int bookId, string userId)
        {
            return _accountRepo.CheckCartItem(bookId, userId);
        }

        public void UpdateQuantity(int id, string userId)
        {
            _accountRepo.UpdateQuantity(id, userId);
        }

        public void AddToCart(Cart cart)
        {
            _accountRepo.AddToCart(cart);
        }
        public List<CartViewModel> GetCart(string userId)
        {
            return _accountRepo.GetCart(userId);
        }

        public void RemoveCart(int cartId)
        {
            _accountRepo.RemoveCart(cartId);
        }

        public void saveInputOrder(InputOrderModel newOrder, string userId)
        {
            _accountRepo.saveInputOrder(newOrder, userId);
        }
    }
}