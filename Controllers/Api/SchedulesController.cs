using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsInventory.Data;
using PartsInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsInventory.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Scheduled> GetScheduleds()
        {
            return _context.Scheduleds.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduled([FromRoute] int id)
        {
            var scheduled =await _context.Scheduleds.SingleOrDefaultAsync(s => s.Id == id);
            return Ok(scheduled);
       
        }


    }
}
