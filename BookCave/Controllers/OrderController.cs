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
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }
    }
}

