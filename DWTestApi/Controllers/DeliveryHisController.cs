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
    public class DeliveryHisController : ControllerBase
    {
        private readonly DeliveryHisDbContext _context;

        public DeliveryHisController(DeliveryHisDbContext context)
        {
            _context = context;
        }

        //전체 배송 이력 확인 GET: api/DeliveryHis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryHis>>> GetDeliveryHis()
        {
            return await _context.DeliveryHis.ToListAsync();
        }

        // GET: api/DeliveryHis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryHis>> GetDeliveryHis(string id)
        {
            var deliveryHis = await _context.DeliveryHis.FindAsync(id);

            if (deliveryHis == null)
            {
                return NotFound();
            }

            return deliveryHis;
        }

        // PUT: api/DeliveryHis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryHis(string id, DeliveryHis deliveryHis)
        {
            if (id != deliveryHis.DeliveryHisId)
            {
                return BadRequest();
            }

            _context.Entry(deliveryHis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryHisExists(id))
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

        //배송 이력을 생성한다. POST: api/DeliveryHis
        [HttpPost]
        public async Task<ActionResult<DeliveryHis>> PostDeliveryHis(DeliveryHis deliveryHis)
        {
            _context.DeliveryHis.Add(deliveryHis);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeliveryHisExists(deliveryHis.DeliveryHisId))
                {
                    return Conflict();
                }
                else
                {

                    throw;
                }
            }

            return CreatedAtAction("GetDeliveryHis", new { id = deliveryHis.DeliveryHisId }, deliveryHis);
        }

        // DELETE: api/DeliveryHis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryHis(string id)
        {
            var deliveryHis = await _context.DeliveryHis.FindAsync(id);
            if (deliveryHis == null)
            {
                return NotFound();
            }

            _context.DeliveryHis.Remove(deliveryHis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryHisExists(string id)
        {
            return _context.DeliveryHis.Any(e => e.DeliveryHisId == id);
        }
    }
}
