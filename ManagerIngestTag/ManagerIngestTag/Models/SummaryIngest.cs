using ManagerIngest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngestTag.Models
{
    public class SummaryIngest
    {
        public TicketIngestFull ticketIngest { get; set; }
        public List<IngestDetailFull> ingestDetail { get; set; }
        public List<HistoryIngestModel> HistoryIngest { get; set; }
    }
}
