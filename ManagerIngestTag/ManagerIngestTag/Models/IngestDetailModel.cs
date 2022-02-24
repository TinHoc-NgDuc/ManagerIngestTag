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
        public DateTime DateSent { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid TicketIngestId { get; set; }
        public Guid IngestTagId { get; set; }
        public Guid CategoryId { get; set; }
        
    }
}
