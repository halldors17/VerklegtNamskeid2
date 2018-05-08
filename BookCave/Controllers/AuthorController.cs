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
    public class AuthorController : Controller
    {
        private AuthorService _authorService;
        
        public AuthorController()
        {
            _authorService = new AuthorService();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var authors = _authorService.GetAllAuthors();
            return View(authors);
        }
        [HttpPost]
        public IActionResult Index(string SearchString)
        {
            var authors = _authorService.GetAuthorsByName(SearchString);
            return View(authors);
        }
        public IActionResult Details(int id)
        {
            var authors = _authorService.GetDetailsAuthor(id);
            return View(authors);
        }
    }
}

