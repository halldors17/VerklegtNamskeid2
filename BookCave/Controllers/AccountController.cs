using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BookCave.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            var user = new ApplicationUser { UserName = register.Email, Email = register.Email };
            var result = await _userManager.CreateAsync(user, register.Password);
            if(result.Succeeded)
            {
                if(!await _roleManager.RoleExistsAsync("User"))
                {
                    var users = new IdentityRole("User");
                    var res = await _roleManager.CreateAsync(users);
                }
                //Success
                await _userManager.AddToRoleAsync(user, "User");
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{register.FirstName} {register.LastName}"));
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
        public IActionResult MyAccount()
        {
            ViewBag.Title = "Notenda síða";
            return View();
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
    }
}
