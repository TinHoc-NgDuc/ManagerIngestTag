using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class IngestDetail
    {
        public Guid IngestDeltailId { get; set; }
        public Guid TicketIngestId { get; set; }
        public Guid IngestTagId { get; set; }
        public Guid CatergoryId { get; set; }
        public DateTime DateSent { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
