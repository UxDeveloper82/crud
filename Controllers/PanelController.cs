using Microsoft.AspNetCore.Mvc;
using PartsInventory.Data.Repository;
using PartsInventory.Models;
using PartsInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsInventory.Controllers
{
    public class PanelController : Controller
    {
        private readonly IPostRepository _repo;

        public PanelController(IPostRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index() 
        {
            var posts = _repo.GetAllPosts();
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new PostViewModel());
            }
            else 
            {
                var post = _repo.GetPost((int)id);
                return View(new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    CreatedBy = post.CreatedBy,
                    Description = post.Description,
                    Category = post.Category,
                });
           
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                CreatedBy = vm.CreatedBy,
                Description = vm.Description,
                Category = vm.Category
            };


            if (post.Id > 0)
                _repo.UpdatePost(post);
            else
                _repo.AddPost(post);
            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);
        }



    }
}
