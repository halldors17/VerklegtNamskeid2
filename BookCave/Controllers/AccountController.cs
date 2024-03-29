using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using BookCave.Services;
using BookCave.Models.InputModels;
using BookCave.Models.EntityModels;
using System;

namespace BookCave.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private AccountService _accountService;
        
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _accountService = new AccountService();
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Innskrá";
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            ViewBag.Title = "Innskrá";
            if(!ModelState.IsValid)
            {
                return View(login);
            }
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Innskráning tókst ekki");
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Title = "Nýr notandi";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register) 
        {
            ViewBag.Title = "Nýr notandi";
            if(!ModelState.IsValid)
            {
                return View(register);
            }
            var user = new ApplicationUser { UserName = register.Email, Email = register.Email, 
                FirstName = register.FirstName, LastName = register.LastName };
            var result = await _userManager.CreateAsync(user, register.Password);
            if(result.Succeeded)
            {
                if(!await _roleManager.RoleExistsAsync("User"))
                {
                    var users = new IdentityRole("User");
                    var res = await _roleManager.CreateAsync(users);
                }
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(register);
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> MyAccount()
        {
            var user = await _userManager.GetUserAsync(User);
            var account = new AccountViewModel();
            account.Id = _userManager.GetUserId(User);
            account.FirstName = user.FirstName;
            account.LastName = user.LastName;
            account.Email = user.Email;
            account.Age = user.Age;
            account.Image = user.Image;
            account.FavBook = user.FavBook;
            account.Shipping = _accountService.GetShippingInfo(_userManager.GetUserId(User));
            ViewBag.Title = "Notenda síða";

            return View(account);
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult ShippingInfo()
        {
            ViewBag.Title = "Flutnings upplýsingar";
            var shippingInfo = new ShippingInfoInputModel();
            var shippingInfoView = _accountService.GetShippingInfo(_userManager.GetUserId(User));
            if(shippingInfoView != null)
            {
                shippingInfo.Id = shippingInfoView.Id;
                shippingInfo.Street = shippingInfoView.Street;
                shippingInfo.City = shippingInfoView.City;
                shippingInfo.PostalCode = shippingInfoView.PostalCode;
                shippingInfo.SendingMethod = shippingInfoView.SendingMethod;
                shippingInfo.Country = shippingInfoView.Country;
            }
            return View(shippingInfo);
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult ShippingInfo(ShippingInfoInputModel shipping)
        {
            ViewBag.Title = "Flutnings upplýsingar";
            if(ModelState.IsValid)
            {
                string userId = _userManager.GetUserId(User);
                _accountService.AddShippingInfo(shipping, userId);
                return RedirectToAction("MyAccount", "Account");

            }
            return View(shipping);
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> EditProfile()
        {
            ViewBag.Title = "Notenda upplýsingar";
            var user = await _userManager.GetUserAsync(User);
            var account = new AccountInputModel();
            account.FirstName = user.FirstName;
            account.LastName = user.LastName;
            account.Email = user.Email;
            account.Age = user.Age;
            account.Image = user.Image;
            account.FavBook = user.FavBook;
            return View(account);
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> EditProfile(AccountInputModel account)
        {
            ViewBag.Title = "Notenda upplýsingar";
            if(!ModelState.IsValid)
            {
                return View(account);
            }
            var user = await _userManager.GetUserAsync(User);
            user.FirstName = account.FirstName;
            user.LastName = account.LastName;
            user.Email = account.Email;
            user.Age = account.Age;
            user.UserName = account.Email;
            user.Image = account.Image;
            user.FavBook = account.FavBook;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("MyAccount", "Account");
        }
        public IActionResult AccessDenied()
        {
            ViewBag.Title = "Aðgang neitað";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            ViewBag.Title = "Greiðslusíða";
            ViewBag.TotalPrice = _accountService.GetTotalForCart(_userManager.GetUserId(User));
            var orderModel = new InputOrderModel();
            var shippingInfoFromDb = _accountService.GetShippingInfo(_userManager.GetUserId(User));
            var user = await _userManager.GetUserAsync(User);
            
            if(shippingInfoFromDb != null)
            {
                orderModel.Name = user.FirstName;
                orderModel.Email = user.Email;
                orderModel.Street = shippingInfoFromDb.Street;    
                orderModel.Street = shippingInfoFromDb.Street;
                orderModel.City = shippingInfoFromDb.City;
                orderModel.PostalCode = shippingInfoFromDb.PostalCode;
                orderModel.Country = shippingInfoFromDb.Country;
                orderModel.SendingMethod = shippingInfoFromDb.SendingMethod;
            }
            return View(orderModel);
        }

        [Authorize(Roles = "User")]
        public IActionResult Confirmation()
        {
            ViewBag.Title = "Staðfesting";
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Checkout(InputOrderModel newOrder)
        {
            ViewBag.TotalPrice = _accountService.GetTotalForCart(_userManager.GetUserId(User));
            ViewBag.Title = "Karfa";
            if(ModelState.IsValid)
            {
                _accountService.saveInputOrder(newOrder, _userManager.GetUserId(User));
                return RedirectToAction("Confirmation");
            }
            return View(newOrder);
        }

        [Authorize(Roles = "User")]
        public IActionResult OrderHistory()
        {
            ViewBag.Title = "Gamlar pantanir";
            var orders =_accountService.GetOrdersForUser(_userManager.GetUserId(User));
            return View(orders);
        }
        [Authorize(Roles = "User")]
        public IActionResult OrderDetails(int id)
        {
            ViewBag.Title = "Pöntunn";
            var order = _accountService.GetOrder(id);
            return View(order);
        }
        [Authorize(Roles = "User")]
        public void AddOrder(Order order)
        {
            _accountService.AddOrder(order);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            if(User.IsInRole("User"))
            {
                var exists = _accountService.CheckCartItem(id, _userManager.GetUserId(User));
                if(exists)
                {
                    _accountService.UpdateQuantity(id, _userManager.GetUserId(User));
                }
                else
                {
                    var cartItem = new Cart
                    {
                        BookId = id,
                        DateCreated = DateTime.Now,
                        UserId = _userManager.GetUserId(User),
                        Quantity = 1
                    };
                    _accountService.AddToCart(cartItem);
                }
            }
            return Ok();
        }

        [Authorize(Roles = "User")]
        public IActionResult RemoveCart(int id)
        {
            _accountService.RemoveCart(id);
            return RedirectToAction("Cart");
        }

        [Authorize(Roles = "User")]
        public IActionResult ReviewOrder()
        {
            ViewBag.Title = "Yfirlit";
            ViewBag.TotalPrice = _accountService.GetTotalForCart(_userManager.GetUserId(User));
            var cart = _accountService.GetCart(_userManager.GetUserId(User));
            ViewBag.Title = "Pöntunn";
            return View(cart);
        }

        [Authorize(Roles = "User")]
        public IActionResult Cart()
        {
            ViewBag.Title = "Karfa";
            ViewBag.TotalPrice = _accountService.GetTotalForCart(_userManager.GetUserId(User));
            var cart = _accountService.GetCart(_userManager.GetUserId(User));
            ViewBag.Title = "Karfa";
            return View(cart);
        }

        [Authorize(Roles = "User")]
        public IActionResult ChangeQuantity(int quantity, int bookId)
        {
            _accountService.ChangeQuantity(quantity, bookId, _userManager.GetUserId(User));
            return RedirectToAction("Cart");
        }
    }
}