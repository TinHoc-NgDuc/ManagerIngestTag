using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Models
{
    public class IngestDetailModel
    {
        public Guid IngestDeltailId { get; set; }
        public string DateSend { get; set; }
        public string DateReturn { get; set; }
        public string RecipientName { get; set; }
        public Guid RecipientId { get; set; }
        public string TakerName { get; set; }
        public Guid TakerId { get; set; }
        public Guid ticketIngestId { get; set; }
        public Guid IngestTagId { get; set; }
    }

    public class IngestDetailFull : IngestDetailModel
    {
        public IngestTagReturnModel IngestTag { get; set; }

    }
}
