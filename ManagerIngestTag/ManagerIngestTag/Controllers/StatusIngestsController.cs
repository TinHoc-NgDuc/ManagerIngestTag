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
    public class StatusIngestsController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusIngestsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/StatusIngests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusIngest>>> GetStatusIngests()
        {
            return await _context.StatusIngests.ToListAsync();
        }

        // GET: api/StatusIngests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusIngest>> GetStatusIngest(Guid id)
        {
            var statusIngest = await _context.StatusIngests.FindAsync(id);

            if (statusIngest == null)
            {
                return NotFound();
            }

            return statusIngest;
        }

        // PUT: api/StatusIngests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusIngest(Guid id, StatusIngest statusIngest)
        {
            if (id != statusIngest.StatusIngestId)
            {
                return BadRequest();
            }

            _context.Entry(statusIngest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusIngestExists(id))
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

        // POST: api/StatusIngests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusIngest>> PostStatusIngest(StatusIngest statusIngest)
        {
            _context.StatusIngests.Add(statusIngest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusIngest", new { id = statusIngest.StatusIngestId }, statusIngest);
        }

        // DELETE: api/StatusIngests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusIngest(Guid id)
        {
            var statusIngest = await _context.StatusIngests.FindAsync(id);
            if (statusIngest == null)
            {
                return NotFound();
            }

            _context.StatusIngests.Remove(statusIngest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusIngestExists(Guid id)
        {
            return _context.StatusIngests.Any(e => e.StatusIngestId == id);
        }
    }
}
