using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookCave.Models.EntityModels;
using BookCave.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ShoppingCartService _shoppingCartService;

         public ShoppingCartController() 
        {
            _shoppingCartService = new ShoppingCartService();
        }
       public IActionResult Index()
        {
            return View();
        }

    }
}