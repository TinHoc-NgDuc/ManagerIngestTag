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
        public async Task<ActionResult<IEnumerable<IngestTagReturnModel>>> GetIngestTags()
        {
            var result = from i in _context.IngestTags
                         select new IngestTagReturnModel
                         {
                             IngestTagId = i.IngestTagId,
                             cardholderName = i.cardholderName,
                             Name = i.Name,
                             Note = i.Note,
                             PositionId = i.Position.PositionId,
                             PositionName = i.Position.Name,
                             Status = i.Status
                         };
            return await result.ToListAsync();
        }

        // GET: api/IngestTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngestTag>> GetIngestTag(Guid id)
        {
            var ingestTag = await _context.IngestTags.FindAsync(id);

            if (ingestTag == null)
            {
                return NotFound();
            }

            return ingestTag;
        }

        // PUT: api/IngestTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngestTag(Guid id, IngestTag ingestTag)
        {
            if (id != ingestTag.IngestTagId)
            {
                return BadRequest();
            }

            _context.Entry(ingestTag).State = EntityState.Modified;

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
        public async Task<ActionResult<IngestTagModel>> PostIngestTag(IngestTagModel ingestTagModel)
        {
            ingestTagModel.IngestTagId = Guid.NewGuid();
            var ingestTag = new IngestTag()
            {
                IngestTagId = ingestTagModel.IngestTagId,
                cardholderName = ingestTagModel.cardholderName,
                Name = ingestTagModel.Name,
                Note = ingestTagModel.Note,
                Status = ingestTagModel.Status,
                Position = _context.Positions.Find(ingestTagModel.PositionId)
            };
            _context.IngestTags.Add(ingestTag);
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
