using CatsTagram.Data;
using CatsTagram.Data.Services;
using CatsTagram.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatsTagram.Controllers
{
    public class PostsController : Controller
    {
        private readonly IpostsService _service;
        private readonly IWebHostEnvironment _environment;
        public PostsController(IpostsService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }
       
        public IActionResult Create()
        {
            return View();
        }
        // POST: Posts/Create
        [HttpPost]

        public IActionResult Create([Bind ("AuthorName , Comment , ImageData")] Post post)
        {
            // Add the new post to the database
            _service.Add(post);

            // Redirect to the Index action to show all posts
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            // Get all posts from the database
            var posts = await _service.GetAll();

            // Render the Index view with the list of posts
            return View(posts);
        }
        //Get: Actors/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var PostDetails =  _service.GetById(id);

            if (PostDetails == null) return View("NotFound");
            return View(PostDetails);
        }
        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails =  _service.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AutherName,ImageData,Comment")] Post post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            object value = await _service.Update(id, post);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var PostDetails =  _service.GetById(id);
            if (PostDetails == null) return View("NotFound");
            return View(PostDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var PosttDetails =  _service.GetById(id);
            if (PosttDetails == null) return View("NotFound");

             _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}