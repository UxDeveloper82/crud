using Microsoft.AspNetCore.Mvc;
using PartsInventory.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsInventory.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _repo;

        public PostsController(IPostRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var posts = _repo.GetAllPosts();
            return View(posts);
        }

        public IActionResult Detail(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }



    }
}
