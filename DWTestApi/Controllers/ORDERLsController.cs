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
    public class ORDERLsController : ControllerBase
    {
        private readonly ORDERLDbContext _context;

        public ORDERLsController(ORDERLDbContext context)
        {
            _context = context;
        }
        `
        //전체 주문리스틑 본다. GET: api/ORDERLs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ORDERL>>> GetORDERL()
        {
            return await _context.ORDERL.ToListAsync();
        }

        //주문 번호로 찾는다. GET: api/ORDERLs/ID/2
        [HttpGet("ID/{id}")]
        public async Task<ActionResult<ORDERL>> GetORDERL(string id)
        {
            var oRDERL = await _context.ORDERL.FindAsync(id);

            if (oRDERL == null)
            {
                return NotFound();
            }

            return oRDERL;
        }

        //배송기사에게 할당된 주문을 찾는다. GET: api/ORDERLs/DID/5/880001
        [HttpGet("DID/{id}/{DID}")]
        public async Task<ActionResult<ORDERL>> GetORDERL(string id,string DID)
        {
            var oRDERL = await _context.ORDERL.FirstOrDefaultAsync(o => o.DELIVER_ID == DID);

            if (oRDERL == null)
            {
                //return BadRequest();
                return NotFound();
            }

            return oRDERL;
        }

        [HttpGet()]

        

        //해당 주문을 배송기사에게 할당한다. PUT: api/ORDERLs/4
        [HttpPut("{id}")]
        public async Task<IActionResult> PutORDERL(string id, ORDERL oRDERL)
        {
            if (id != oRDERL.ORDERLID)
            {
                return BadRequest();
            }

            _context.Entry(oRDERL).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORDERLExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        //주문 입력 POST: api/ORDERLs
        [HttpPost]
        public async Task<ActionResult<ORDERL>> PostORDERL(ORDERL oRDERL)
        {
            _context.ORDERL.Add(oRDERL);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ORDERLExists(oRDERL.ORDERLID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetORDERL", new { id = oRDERL.ORDERLID }, oRDERL);
        }

        //주문 삭제 DELETE: api/ORDERLs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteORDERL(string id)
        {
            var oRDERL = await _context.ORDERL.FindAsync(id);
            if (oRDERL == null)
            {
                return NotFound();
            }

            _context.ORDERL.Remove(oRDERL);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ORDERLExists(string id)
        {
            return _context.ORDERL.Any(e => e.ORDERLID == id);
        }
    }
}
