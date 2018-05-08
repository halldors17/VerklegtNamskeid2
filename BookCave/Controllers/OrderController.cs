using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;

namespace BookCave.Controllers
{
    public class OrderController : Controller
    {
        private OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult ReviewOrder()
        {
            return View();
        }
    }
}

