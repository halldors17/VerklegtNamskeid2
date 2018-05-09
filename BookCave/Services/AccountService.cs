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

        public bool CheckCartItem(int bookId, string userId)
        {
            return _accountRepo.CheckCartItem(bookId, userId);
        }

        public void UpdateQuantity(int bookId, string userId)
        {
            _accountRepo.UpdateQuantity(bookId, userId);
        }

        public void AddToCart(Cart cart)
        {
            _accountRepo.AddToCart(cart);
        }
    }
}