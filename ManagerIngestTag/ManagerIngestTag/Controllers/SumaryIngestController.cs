using ManagerIngest.Infrastructure;
using ManagerIngest.Models;
using ManagerIngestTag.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerIngestTag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumaryIngestController : ControllerBase
    {
        private readonly DataContext _context;
        public SumaryIngestController(DataContext context)
        {
            _context = context;
        }
        // GET: api/<SumaryIngestController>
        [HttpGet]
        public IEnumerable<SummaryIngest> Get()
        {
            List<SummaryIngest> result = new List<SummaryIngest>();
            //select all ticket
            var query = from tk in _context.TicketIngests
                        select new TicketIngestModel
                        {
                            TicketIngestId = tk.TicketIngestId,
                            Name = tk.Name,
                            CreateName = tk.CreateName,
                            TopicName = tk.TopicName,
                            ProgramName = tk.ProductionName,
                            CameramanName = tk.CameramanName,
                            ProductionName = tk.ProductionName,
                            ReporterName = tk.ReporterName,
                            SaveDocument = tk.SaveDocument,
                            IsReporting = tk.IsReporting,
                            IsNew = tk.IsNew,
                            IsCategory = tk.IsCategory,
                            IsOtherProgram = tk.IsOtherProgram,
                            StatusIngest = tk.StatusIngest
                        };
            var data = query.ToList();
            //get all ticket 
            foreach (var item in data)
            {
                SummaryIngest summary = new SummaryIngest();
                summary.ticketIngest = new TicketIngestFull
                {
                    TicketIngestId = item.TicketIngestId,
                    Name = item.Name,
                    CreateName = item.CreateName,
                    TopicName = item.TopicName,
                    ProgramName = item.ProductionName,
                    CameramanName = item.CameramanName,
                    ProductionName = item.ProductionName,
                    ReporterName = item.ReporterName,
                    SaveDocument = item.SaveDocument,
                    IsReporting = item.IsReporting,
                    IsNew = item.IsNew,
                    IsCategory = item.IsCategory,
                    IsOtherProgram = item.IsOtherProgram,
                    StatusIngest = item.StatusIngest,
                    
                };
                
                summary.ticketIngest.StatusName = (from st in _context.StatusIngests
                         where st.StatusCode.Contains(item.StatusIngest)
                         select new StatusIngestModel { 
                             Name = st.Name,
                             StatusCode = st.StatusCode,
                             StatusIngestId =st.StatusIngestId
                         }).ToList().FirstOrDefault().Name;
                var query2 = from id in _context.IngestDetails
                             where id.ticketIngest.TicketIngestId == item.TicketIngestId
                             select new IngestDetailFull
                             {
                                 IngestDeltailId = id.IngestDeltailId,
                                 DateReturn = id.DateReturn,
                                 DateSend = id.DateSend,
                                 IngestTagId = id.IngestTag.IngestTagId,
                                 RecipientName = id.RecipientName,
                                 TakerName = id.TakerName,
                                 TakerId = id.TakerId,
                                 ticketIngestId= id.ticketIngest.TicketIngestId,
                                 RecipientId = id.RecipientId,
                                 IngestTag = new IngestTagReturnModel
                                 {
                                     IngestTagId = id.IngestTag.IngestTagId,
                                     IngestCode = id.IngestTag.IngestCode,
                                     Name = id.IngestTag.Name,
                                     Note = id.IngestTag.Note,
                                     Status = id.IngestTag.Status,
                                     CategoryId = id.IngestTag.category.CategoryId,
                                     cardholderId = id.IngestTag.cardholderId,
                                     EmployeeId = id.IngestTag.Employee.EmployeeId,
                                     CardholderName = id.IngestTag.Employee.Name,
                                     CategoryName = id.IngestTag.category.Name
                                 }
                             };
                summary.ingestDetail = query2.ToList();
                summary.ticketIngest.IngestDetailFull = summary.ingestDetail;
                result.Add(summary);
            }

            return result;
        }

        // POST api/<SumaryIngestController>
        //[HttpPost]
        //public async Task<ActionResult<SummaryIngest>> Post(SummaryIngest summaryIngest)
        //{
        //    return null;
        //}

        // PUT api/<SumaryIngestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SumaryIngestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
