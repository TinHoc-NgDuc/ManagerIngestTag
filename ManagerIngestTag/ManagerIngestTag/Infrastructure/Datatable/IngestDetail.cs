using ManagerIngestTag.Infrastructure.Datatable;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class IngestDetail
    {
        [Key]
        public Guid IngestDeltailId { get; set; }
        public TicketIngest TicketIngest { get; set; }
        public string EmployeeSend { get; set; }
        public string EmployeeReceive { get; set; }
        public string DateSend { get; set; }
        public string DateReceive { get; set; }
        public string Recipient { get; set; }
        public IngestTag IngestTag { get; set; }
    }
}
