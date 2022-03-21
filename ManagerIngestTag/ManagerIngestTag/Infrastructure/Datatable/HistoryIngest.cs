using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class HistoryIngest
    {
        [Key]
        public Guid HistoryIngestId { get; set; }
        public string ActionCode { get; set; }
        public string NameAction { get; set; }
        public string Performer { get; set; }
        public DateTime TimeAction { get; set; }
        public IngestDetail IngestDetail { get; set; }
        public TicketIngest TicketIngest { get; set; }
    }
}
