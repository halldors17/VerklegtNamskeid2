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
            account.Age = user.age;
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
            if(shippingInfo == null)
            {
                return View();
            }
            shippingInfo.Id = shippingInfoView.Id;
            shippingInfo.Street = shippingInfoView.Street;
            shippingInfo.City = shippingInfoView.City;
            shippingInfo.PostalCode = shippingInfoView.PostalCode;
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
            account.Age = user.age;
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
            user.age = account.Age;
            user.UserName = account.Email;
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

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult OrderHistory()
        {
            var orders =_accountService.GetOrdersForUser(_userManager.GetUserId(User));
            return View(orders);
        }

        public IActionResult OrderDetails(int orderId)
        {
            var order = _accountService.GetOrder(orderId);
            return View(order);
        }

        public void AddOrder(Order order)
        {
            _accountService.AddOrder(order);
        }

        [HttpPost]
        public IActionResult AddToCart(int bookId)
        {
            if(User.IsInRole("User"))
            {
                var exists = _accountService.CheckCartItem(bookId, _userManager.GetUserId(User));
                if(exists)
                {
                    _accountService.UpdateQuantity(bookId, _userManager.GetUserId(User));
                }
                else
                {
                    var cartItem = new Cart
                    {
                        BookId = bookId,
                        DateCreated = DateTime.Now,
                        CustomerId = _userManager.GetUserId(User),
                        Quantity = 1
                    };
                    _accountService.AddToCart(cartItem);
                }
            }
            return Ok();
        }
        
        public IActionResult Cart()
        {
            if(User.IsInRole("User"))
            {
                var cart = _accountService.GetCart(_userManager.GetUserId(User));
                return View(cart);
            }
            else{
            return Content("Þú þarft að vera innskráður til að fá aðgang að körfunni");
            }
        }
    }
}