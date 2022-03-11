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
    public class IngestDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public IngestDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/IngestDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngestDetail>>> GetIngestDetails()
        {
            return await _context.IngestDetails.ToListAsync();
        }

        // GET: api/IngestDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngestDetail>> GetIngestDetail(Guid id)
        {
            var ingestDetail = await _context.IngestDetails.FindAsync(id);

            if (ingestDetail == null)
            {
                return NotFound();
            }

            return ingestDetail;
        }

        // PUT: api/IngestDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngestDetail(Guid id, IngestDetail ingestDetail)
        {
            if (id != ingestDetail.IngestDeltailId)
            {
                return BadRequest();
            }

            _context.Entry(ingestDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngestDetailExists(id))
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

        // POST: api/IngestDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngestDetail>> PostIngestDetail(IngestDetailFull[] ingestDetail)
        {
            foreach (var item in ingestDetail)
            {
                IngestDetail ingest = new IngestDetail()
                {
                    IngestDeltailId = Guid.NewGuid(),
                    EmployeeSend = item.EmployeeSend,
                    EmployeeReceive = item.EmployeeReceive,
                    DateSend = item.DateSend,
                    DateReceive = item.DateReceive,
                    Recipient = item.Recipient,
                    TicketIngest = _context.TicketIngests.Find(item.TicketIngestId),
                    IngestTag = _context.IngestTags.Find(item.IngestId)
                };
                _context.IngestDetails.Add(ingest);
            }
            //_context.IngestDetails.Add(ingestDetail);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetIngestDetails", ingestDetail);

            //return null;
        }


        // DELETE: api/IngestDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngestDetail(Guid id)
        {
            var ingestDetail = await _context.IngestDetails.FindAsync(id);
            if (ingestDetail == null)
            {
                return NotFound();
            }

            _context.IngestDetails.Remove(ingestDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngestDetailExists(Guid id)
        {
            return _context.IngestDetails.Any(e => e.IngestDeltailId == id);
        }
    }
}
