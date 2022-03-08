using ManagerIngestTag.Infrastructure.Datatable;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class IngestDetail
    {
        [Key]
        public Guid IngestDeltailId { get; set; }
        public DateTime DateSent { get; set; }
        public Guid EmployeeId { get; set; }
        public TicketIngest TicketIngest { get; set; }
        public IngestTag IngestTag { get; set; }
        public Category Category { get; set; }
        
    }
}
