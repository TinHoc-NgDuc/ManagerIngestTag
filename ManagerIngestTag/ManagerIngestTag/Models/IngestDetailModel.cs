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
        public Guid TicketIngestId { get; set; }
        public string EmployeeSend { get; set; }
        public string EmployeeReceive { get; set; }
        public string DateSend { get; set; }
        public string DateReceive { get; set; }
        public string Recipient { get; set; }

    }

    public class IngestDetailCreate : IngestDetailModel
    {
        public Guid EmployeeSendId { get; set; }
        public Guid EmployeeReceiveId{ get; set; }
        public IngestTagModel Ingest { get; set; }
    }
}
