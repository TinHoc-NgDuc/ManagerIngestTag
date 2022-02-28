using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public CategoryModel Category { get; set; }
        
    }
}
