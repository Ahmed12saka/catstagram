using CatsTagram.Data;
using CatsTagram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CatsTagram.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public HomeController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var AllPosts = await _context.CatPosts
                .Include(cp => cp.Hashtags)
                .OrderByDescending(cp => cp.DateAdded)
                .ToListAsync();
            return View(AllPosts);
        }
    }
}