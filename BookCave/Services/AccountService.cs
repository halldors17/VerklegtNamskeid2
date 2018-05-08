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
            
        }
    }
}