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
    public class IngestTagsController : ControllerBase
    {
        private readonly DataContext _context;

        public IngestTagsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/IngestTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngestTag>>> GetIngestTags()
        {
            return await _context.IngestTags.ToListAsync();
        }

        // GET: api/IngestTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngestTagModel>> GetIngestTag(Guid id)
        {
            var ingestTag = await _context.IngestTags.FindAsync(id);

            if (ingestTag == null)
            {
                return NotFound();
            }

            return new IngestTagModel
            {
                IngestTagId = ingestTag.IngestTagId,
                Name = ingestTag.Name,
                Note = ingestTag.Note,
                Status = ingestTag.Status,
                cardholderCode = ingestTag.Employee.EmployeeId
            };
        }

        // PUT: api/IngestTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngestTag(Guid id, IngestTagModel ingestTag)
        {
            if (id != ingestTag.IngestTagId)
            {
                return BadRequest();
            }
            IngestTag ingest = new IngestTag
            {
                IngestTagId = ingestTag.IngestTagId,
                Name = ingestTag.Name,
                Note = ingestTag.Note,
                Status = ingestTag.Status,
                cardholderCode = ingestTag.cardholderCode,
                Employee = _context.Employees.Find(ingestTag.cardholderCode)
            };
            _context.Entry(ingest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngestTagExists(id))
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

        // POST: api/IngestTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngestTagModel>> PostIngestTag(IngestTagModel ingestTag)
        {
            IngestTag itag = new IngestTag
            {
                IngestTagId = ingestTag.IngestTagId,
                Name = ingestTag.Name,
                Note = ingestTag.Note,
                Status = ingestTag.Status,
                cardholderCode = ingestTag.cardholderCode,
                Employee = _context.Employees.Find(ingestTag.cardholderCode)
            };
            _context.IngestTags.Add(itag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngestTag", new { id = ingestTag.IngestTagId }, ingestTag);
        }

        // DELETE: api/IngestTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngestTag(Guid id)
        {
            var ingestTag = await _context.IngestTags.FindAsync(id);
            if (ingestTag == null)
            {
                return NotFound();
            }

            _context.IngestTags.Remove(ingestTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngestTagExists(Guid id)
        {
            return _context.IngestTags.Any(e => e.IngestTagId == id);
        }
    }
}
