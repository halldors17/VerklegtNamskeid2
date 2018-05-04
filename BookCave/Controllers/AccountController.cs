using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BookCave.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
            return View();
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
            ViewBag.Title = "Nýr Notandi";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register) 
        {
            ViewBag.Title = "Nýr Notandi";
            if(!ModelState.IsValid)
            {
                return View(register);
            }
            var user = new ApplicationUser { UserName = register.Email, Email = register.Email };
            var result = await _userManager.CreateAsync(user, register.Password);
            if(result.Succeeded)
            {
                //Success
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{register.FirstName} {register.LastName}"));
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult AccessDenied()
        {
            ViewBag.Title = "Þú hefur ekki leyfi fyrir að vera hér >:(";
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
