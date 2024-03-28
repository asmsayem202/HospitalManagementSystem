using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Library.DAL;
using HMS.Library.Models;

namespace HMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowupsController : ControllerBase
    {
        private readonly HMSdb _context;

        public FollowupsController(HMSdb context)
        {
            _context = context;
        }

        // GET: api/Followups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Followup>>> GetFollowups()
        {
            return await _context.Followups.ToListAsync();
        }

        // GET: api/Followups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Followup>> GetFollowup(int id)
        {
            var followup = await _context.Followups.FindAsync(id);

            if (followup == null)
            {
                return NotFound();
            }

            return followup;
        }

        // PUT: api/Followups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollowup(int id, Followup followup)
        {
            if (id != followup.FollowupId)
            {
                return BadRequest();
            }

            _context.Entry(followup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowupExists(id))
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

        // POST: api/Followups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Followup>> PostFollowup(Followup followup)
        {
            _context.Followups.Add(followup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFollowup", new { id = followup.FollowupId }, followup);
        }

        // DELETE: api/Followups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFollowup(int id)
        {
            var followup = await _context.Followups.FindAsync(id);
            if (followup == null)
            {
                return NotFound();
            }

            _context.Followups.Remove(followup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FollowupExists(int id)
        {
            return _context.Followups.Any(e => e.FollowupId == id);
        }
    }
}
