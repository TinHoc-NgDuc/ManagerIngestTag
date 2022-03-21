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
using Microsoft.Extensions.Configuration;

namespace ManagerIngestTag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketIngestsController : ControllerBase
    {
        private readonly DataContext _context;
        public IConfiguration Configuration { get; }
        string Darft { get; set; }
        string Pending { get; set; }
        string SentFile { get; set; }
        string ReturnTag { get; set; }
        string Approved { get; set; }

        string DarftName { get; set; }
        string PendingName { get; set; }
        string SentFileName { get; set; }
        string ReturnTagName { get; set; }
        string ApprovedName { get; set; }
        public TicketIngestsController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
            Darft = Configuration.GetValue<string>("Darft");
            Pending = Configuration.GetValue<string>("Pending");
            SentFile = Configuration.GetValue<string>("SentFile");
            ReturnTag = Configuration.GetValue<string>("ReturnTag");
            Approved = Configuration.GetValue<string>("Approved");

            DarftName = Configuration.GetValue<string>("DarftName");
            PendingName = Configuration.GetValue<string>("PendingName");
            SentFileName = Configuration.GetValue<string>("SentFileName");
            ReturnTagName = Configuration.GetValue<string>("ReturnTagName");
            ApprovedName = Configuration.GetValue<string>("ApprovedName");
        }

        // GET: api/TicketIngests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketIngestModel>>> GetTicketIngests()
        {
            var result = from t in _context.TicketIngests
                         select new TicketIngestModel
                         {
                             TicketIngestId = Guid.NewGuid(),
                             Name = t.Name,
                             CreateName = t.CreateName,
                             TopicName = t.TopicName,
                             ProgramName = t.ProductionName,
                             CameramanName = t.CameramanName,
                             ProductionName = t.ProductionName,
                             ReporterName = t.ReporterName,
                             SaveDocument = t.SaveDocument,
                             IsReporting = t.IsReporting,
                             IsNew = t.IsNew,
                             IsCategory = t.IsCategory,
                             IsOtherProgram = t.IsOtherProgram,
                             StatusIngest = t.StatusIngest
                         };
            return await result.ToListAsync();
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

        // PUT: api/TicketIngests/{code}
        [HttpPut]
        public async Task<IActionResult> PutTicketIngest(TicketIngestFull ticketIngest)
        {
            try
            {
                var ticket = await _context.TicketIngests.FindAsync(ticketIngest.TicketIngestId);
                if (ticket == null)
                {
                    return NotFound();
                }
                else
                {
                    var checkStatus = true;
                    foreach (var item in ticketIngest.IngestDetailFull)
                    {
                        if (item.Status != ticketIngest.IngestDetailFull[0].Status)
                        {
                            checkStatus = false;
                        }
                        var ingestDetail = _context.IngestDetails.Find(item.IngestDeltailId);
                        ingestDetail.Status = item.Status;
                        ingestDetail.TakerName = item.TakerName;
                        ingestDetail.TakerId = item.TakerId;
                        ingestDetail.DateReturn = item.DateReturn;
                        HistoryIngest historyIngest = new();
                        historyIngest.HistoryIngestId = Guid.NewGuid();
                        historyIngest.ActionCode = item.Status;
                        if (item.Status.ToLower() == Pending.ToLower())
                        {
                            historyIngest.NameAction = PendingName;
                            historyIngest.Performer = ticketIngest.CreateName;
                        }
                        else if (item.Status.ToLower() == SentFile.ToLower())
                        {
                            historyIngest.NameAction = SentFileName;
                            historyIngest.Performer = item.RecipientName;
                        }
                        else if (item.Status.ToLower() == Approved.ToLower())
                        {
                            historyIngest.NameAction = ApprovedName;
                            historyIngest.Performer = item.RecipientName;
                        }
                        else if (item.Status.ToLower() == ReturnTag.ToLower())
                        {
                            historyIngest.NameAction = ReturnTagName;
                            historyIngest.Performer = item.TakerName;
                        }
                        historyIngest.TimeAction = DateTime.Now;
                        historyIngest.IngestDetail = _context.IngestDetails.Find(item.IngestDeltailId);
                        historyIngest.TicketIngest = _context.TicketIngests.Find(ticketIngest.TicketIngestId);
                        _context.HistoryIngests.Add(historyIngest);
                    }
                    if (checkStatus)
                    {
                        ticket.StatusIngest = ticketIngest.IngestDetailFull[0].Status;
                    }
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }
        // POST: api/TicketIngests
        [HttpPost]
        public async Task<ActionResult<TicketIngest>> PostTicketIngest(TicketIngestFull ticketIngest)
        {
            try
            {
                var tickketIngest = new TicketIngest()
                {
                    TicketIngestId = Guid.NewGuid(),
                    Name = ticketIngest.Name,
                    CreateName = ticketIngest.CreateName,
                    TopicName = ticketIngest.TopicName,
                    ProgramName = ticketIngest.ProductionName,
                    CameramanName = ticketIngest.CameramanName,
                    ProductionName = ticketIngest.ProductionName,
                    ReporterName = ticketIngest.ReporterName,
                    SaveDocument = ticketIngest.SaveDocument,
                    IsReporting = ticketIngest.IsReporting,
                    IsNew = ticketIngest.IsNew,
                    IsCategory = ticketIngest.IsCategory,
                    IsOtherProgram = ticketIngest.IsOtherProgram,
                    StatusIngest = ticketIngest.StatusIngest
                };
                _context.TicketIngests.Add(tickketIngest);

                foreach (var item in ticketIngest.IngestDetailFull)
                {
                    var ingestDetail = new IngestDetail()
                    {
                        IngestDeltailId = Guid.NewGuid(),
                        DateSend = item.DateSend,
                        DateReturn = item.DateReturn,
                        RecipientName = item.RecipientName,
                        RecipientId = item.RecipientId,
                        TakerName = item.TakerName,
                        TakerId = item.TakerId,
                        ticketIngest = _context.TicketIngests.Find(tickketIngest.TicketIngestId),
                        IngestTag = _context.IngestTags.Find(item.IngestTag.IngestTagId),
                        Status = item.Status
                        //IngestTag = new IngestTag()
                        //{
                        //    IngestTagId = item.IngestTag.IngestTagId,
                        //    IngestCode = item.IngestTag.IngestCode,
                        //    Name = item.IngestTag.Name,
                        //    Note = item.IngestTag.Note,
                        //    Status = item.IngestTag.Status,
                        //    category = _context.Categories.Find(item.IngestTag.CategoryId),
                        //    cardholderId = item.IngestTag.cardholderId,
                        //    Employee = _context.Employees.Find(item.IngestTag.cardholderId)
                        //}
                    };
                    _context.IngestDetails.Add(ingestDetail);
                    HistoryIngest historyIngest = new();
                    historyIngest.HistoryIngestId = Guid.NewGuid();
                    historyIngest.ActionCode = Pending;
                    historyIngest.NameAction = PendingName;
                    historyIngest.Performer = ticketIngest.CreateName;
                    historyIngest.TimeAction = DateTime.Now;
                    historyIngest.TicketIngest = _context.TicketIngests.Find(tickketIngest.TicketIngestId);
                    historyIngest.IngestDetail = _context.IngestDetails.Find(ingestDetail.IngestDeltailId);

                    _context.HistoryIngests.Add(historyIngest);
                }

                await _context.SaveChangesAsync();
                ticketIngest.TicketIngestId = tickketIngest.TicketIngestId;
                return CreatedAtAction("GetTicketIngest", new { id = tickketIngest.TicketIngestId }, ticketIngest);
            }
            catch (Exception ex)
            {
                return null;
            }
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

        //private bool TicketIngestExists(Guid id)
        //{
        //    return _context.TicketIngests.Any(e => e.TicketIngestId == id);
        //}
    }
}
