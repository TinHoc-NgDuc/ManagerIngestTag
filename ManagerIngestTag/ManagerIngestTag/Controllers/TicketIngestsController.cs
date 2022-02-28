using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagerIngest.Infrastructure;
using ManagerIngest.Infrastructure.Datatable;

namespace ManagerIngestTag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketIngestsController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketIngestsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TicketIngests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketIngest>>> GetTicketIngests()
        {
            return await _context.TicketIngests.ToListAsync();
        }

        // GET: api/TicketIngests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketIngest>> GetTicketIngest(Guid id)
        {
            var ticketIngest = await _context.TicketIngests.FindAsync(id);

            if (ticketIngest == null)
            {
                return NotFound();
            }

            return ticketIngest;
        }

        // PUT: api/TicketIngests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketIngest(Guid id, TicketIngest ticketIngest)
        {
            if (id != ticketIngest.TicketIngestId)
            {
                return BadRequest();
            }

            _context.Entry(ticketIngest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketIngestExists(id))
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

        // POST: api/TicketIngests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketIngest>> PostTicketIngest(TicketIngest ticketIngest)
        {
            _context.TicketIngests.Add(ticketIngest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketIngest", new { id = ticketIngest.TicketIngestId }, ticketIngest);
        }

        // DELETE: api/TicketIngests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketIngest(Guid id)
        {
            var ticketIngest = await _context.TicketIngests.FindAsync(id);
            if (ticketIngest == null)
            {
                return NotFound();
            }

            _context.TicketIngests.Remove(ticketIngest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketIngestExists(Guid id)
        {
            return _context.TicketIngests.Any(e => e.TicketIngestId == id);
        }
    }
}
