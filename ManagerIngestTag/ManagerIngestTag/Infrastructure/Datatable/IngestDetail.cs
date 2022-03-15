using ManagerIngestTag.Infrastructure.Datatable;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class IngestDetail
    {
        [Key]
        public Guid IngestDeltailId { get; set; }
        public string DateSend { get; set; }
        public string DateReturn { get; set; }
        public string RecipientName { get; set; }
        public Guid RecipientId { get; set; }
        public string TakerName { get; set; }
        public Guid TakerId { get; set; }
        public TicketIngest ticketIngest { get; set; }
        public IngestTag IngestTag { get; set; }
    }
}
