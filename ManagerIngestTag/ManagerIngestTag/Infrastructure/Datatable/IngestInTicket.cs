using ManagerIngest.Infrastructure.Datatable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngestTag.Infrastructure.Datatable
{
    public class IngestInTicket
    {
        [Key]
        public Guid Id { get; set; }
        public IngestTag ingestTag { get; set; }
        public TicketIngest TicketIngest { get; set; }
    }
}
