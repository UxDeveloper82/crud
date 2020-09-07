using Microsoft.AspNetCore.Mvc;
using PartsInventory.Data;
using PartsInventory.Models;
using PartsInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsInventory.Controllers
{
    public class MyMessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyMessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mymessages = _context.MyMessages.ToList();
            return View(mymessages);
        
        }

        public IActionResult NewMessage()
        {
            var viewModel = new MyMessagesViewModel();
            return View(viewModel); 
        }

        [HttpPost]
        public IActionResult CreateMessage(MyMessage mymessage)
        {
            _context.MyMessages.Add(mymessage);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
