using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsInventory.Data;
using PartsInventory.Models;

namespace PartsInventory.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyMessagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MyMessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MyMessages
        [HttpGet]
        public IEnumerable<MyMessage> GetMyMessages()
        {
            return _context.MyMessages;
        }

        // GET: api/MyMessages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMyMessage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var myMessage = await _context.MyMessages.FindAsync(id);

            if (myMessage == null)
            {
                return NotFound();
            }

            return Ok(myMessage);
        }

        // PUT: api/MyMessages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyMessage([FromRoute] int id, [FromBody] MyMessage myMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myMessage.Id)
            {
                return BadRequest();
            }

            _context.Entry(myMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyMessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MyMessages
        [HttpPost]
        public async Task<IActionResult> PostMyMessage([FromBody] MyMessage myMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MyMessages.Add(myMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyMessage", new { id = myMessage.Id }, myMessage);
        }

        // DELETE: api/MyMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyMessage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var myMessage = await _context.MyMessages.FindAsync(id);
            if (myMessage == null)
            {
                return NotFound();
            }

            _context.MyMessages.Remove(myMessage);
            await _context.SaveChangesAsync();

            return Ok(myMessage);
        }

        private bool MyMessageExists(int id)
        {
            return _context.MyMessages.Any(e => e.Id == id);
        }
    }
}