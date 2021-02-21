using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DWTestApi.Models;

namespace DWTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrivesController : ControllerBase
    {

        private readonly ArriveDbContext _context;

        public ArrivesController(ArriveDbContext context)
        {
            _context = context;
        }

        // GET: api/Arrives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arrive>>> GetArrive()
        {
            return await _context.Arrive.ToListAsync();
        }

        // GET: api/Arrives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Arrive>> GetArrive(string id)
        {
            var arrive = await _context.Arrive.FindAsync(id);

            if (arrive == null)
            {
                return NotFound();
            }

            return arrive;
        }

        // PUT: api/Arrives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrive(string id, Arrive arrive)
        {
            if (id != arrive.ArriveId)
            {
                return BadRequest();
            }

            _context.Entry(arrive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArriveExists(id))
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

        //배송완료 정보를 입력한다. POST: api/Arrives
        [HttpPost]
        public async Task<ActionResult<Arrive>> PostArrive(Arrive arrive)
        {
            _context.Arrive.Add(arrive);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArriveExists(arrive.ArriveId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArrive", new { id = arrive.ArriveId }, arrive);
        }

        // DELETE: api/Arrives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArrive(string id)
        {
            var arrive = await _context.Arrive.FindAsync(id);
            if (arrive == null)
            {
                return NotFound();
            }

            _context.Arrive.Remove(arrive);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArriveExists(string id)
        {
            return _context.Arrive.Any(e => e.ArriveId == id);
        }
    }
}
