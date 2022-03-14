using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagerIngest.Infrastructure;
using ManagerIngest.Infrastructure.Datatable;
using ManagerIngest.Models;

namespace ManagerIngestTag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryIngestsController : ControllerBase
    {
        private readonly DataContext _context;

        public HistoryIngestsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/HistoryIngests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryIngest>>> GetHistoryIngests()
        {
            return await _context.HistoryIngests.ToListAsync();
        }

        // GET: api/HistoryIngests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryIngest>> GetHistoryIngest(Guid id)
        {
            var historyIngest = await _context.HistoryIngests.FindAsync(id);

            if (historyIngest == null)
            {
                return NotFound();
            }

            return historyIngest;
        }

        // PUT: api/HistoryIngests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoryIngest(Guid id, HistoryIngest historyIngest)
        {
            if (id != historyIngest.HistoryIngestId)
            {
                return BadRequest();
            }

            _context.Entry(historyIngest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryIngestExists(id))
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

        // POST: api/HistoryIngests
        [HttpPost]
        public async Task<ActionResult<HistoryIngest>> PostHistoryIngest(HistoryIngestModel historyIngest)
        {

            HistoryIngest history = new HistoryIngest();
            history.HistoryIngestId = Guid.NewGuid();
            history.ActionCode = historyIngest.ActionCode;
            history.NameAction = historyIngest.NameAction;
            history.Performer = historyIngest.Performer;
            history.TimeAction = DateTime.Now.ToString("h:m")+" " + DateTime.Now.ToString("dd/M/yyyy");
            history.IngestDetail = _context.IngestDetails.Find(historyIngest.IngestDetailId);

            _context.HistoryIngests.Add(history);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoryIngest", new { id = history.HistoryIngestId }, historyIngest);
        }

        // DELETE: api/HistoryIngests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoryIngest(Guid id)
        {
            var historyIngest = await _context.HistoryIngests.FindAsync(id);
            if (historyIngest == null)
            {
                return NotFound();
            }

            _context.HistoryIngests.Remove(historyIngest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoryIngestExists(Guid id)
        {
            return _context.HistoryIngests.Any(e => e.HistoryIngestId == id);
        }
    }
}
