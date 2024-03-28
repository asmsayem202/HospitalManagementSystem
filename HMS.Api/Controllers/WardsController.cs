using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Library.DAL;
using HMS.Library.Models;
using System.Diagnostics;

namespace HMS.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WardsController : ControllerBase
	{
		private readonly HMSdb _context;

		public WardsController(HMSdb context)
		{
			_context = context;
		}

		// GET: api/Wards
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Ward>>> GetWards()
		{
			return await _context.Wards.Include(i => i.Nurses).Include(i => i.Rooms).ToListAsync();
		}

		// GET: api/Wards/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Ward>> GetWard(int id)
		{
			var ward = await _context.Wards.Include(d => d.Nurses).Include(d => d.Rooms).FirstOrDefaultAsync(m => m.WardId == id);

			if (ward == null)
			{
				return NotFound();
			}

			return ward;
		}

		// PUT: api/Wards/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutWard(int id, Ward ward)
		{
			if (id != ward.WardId)
			{
				return BadRequest();
			}

			//_context.Entry(ward).State = EntityState.Modified;

			try
			{
				_context.Update(ward);

				var NursesList = ward.Nurses.Select(d => d.NurseId).ToList();
				var delNurses = await _context.Nurses.Where(i => i.WardID == id).Where(i => !NursesList.Contains(i.NurseId)).ToListAsync();
				_context.Nurses.RemoveRange(delNurses);

				var RoomsList = ward.Rooms.Select(d => d.RoomId).ToList();
				var delRooms = await _context.Rooms.Where(i => i.WardID == id).Where(i => !RoomsList.Contains(i.RoomId)).ToListAsync();
				_context.Rooms.RemoveRange(delRooms);

				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!WardExists(id))
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

		// POST: api/Wards
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Ward>> PostWard(Ward ward)
		{
			_context.Wards.Add(ward);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetWard", new { id = ward.WardId }, ward);
		}

		// DELETE: api/Wards/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteWard(int id)
		{
			try
			{
				var ward = await _context.Wards.FindAsync(id);
				if (ward == null)
				{
					return NotFound();
				}

				_context.Nurses.RemoveRange(_context.Nurses.Where(i => i.WardID == id));
				_context.Rooms.RemoveRange(_context.Rooms.Where(i => i.WardID == id));


				_context.Wards.Remove(ward);
				await _context.SaveChangesAsync();

				return NoContent();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				return BadRequest(ex.Message);
			}
		}

		private bool WardExists(int id)
		{
			return _context.Wards.Any(e => e.WardId == id);
		}
	}
}
