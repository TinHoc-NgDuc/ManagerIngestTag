using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Models
{
    public class HistoryIngestModel
    {
        public Guid HistoryIngestId { get; set; }
        public string ActionCode { get; set; }
        public string NameAction { get; set; }
        public string Performer { get; set; }
        public string TimeAction { get; set; }
        public Guid TicketIngestId { get; set; }
    }
}
