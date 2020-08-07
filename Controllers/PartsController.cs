using Microsoft.AspNetCore.Mvc;
using PartsInventory.Data;
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
    public class PartsController : Controller
    {
        private readonly IRepository _repo;

        public PartsController(IRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index() {

            var parts = _repo.GetAllParts();

            return View(parts);
        }

        public IActionResult Details(int id) {

            var part = _repo.GetPart(id);
            return View(part);
        }

        [HttpGet]
        public ActionResult Edit(int? id) {
            if (id == null)
                return View(new PartViewModel());
            else
            {
                var part = _repo.GetPart((int)id);
                return View(new PartViewModel
                {
                    Id = part.Id,
                    PartName = part.PartName,
                    PartNumber = part.PartNumber,
                    PartDescription = part.PartDescription,
                    NumberInStock = part.NumberInStock,
                    PartPrice = part.PartPrice
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PartViewModel vm) {
            var part = new Part
            {
                Id = vm.Id,
                PartName = vm.PartName,
                PartNumber = vm.PartNumber,
                PartDescription = vm.PartDescription,
                NumberInStock = vm.NumberInStock,
                PartPrice = vm.PartPrice

            };

            if (part.Id > 0)
                _repo.UpdatePart(part);
            else
                _repo.AddPart(part);
            if (await _repo.SaveChangeAsync())
                return RedirectToAction("Index");
            else
                return View(part);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePart(id);
            await _repo.SaveChangeAsync();
            return RedirectToAction("Index");
        }

    }
}
