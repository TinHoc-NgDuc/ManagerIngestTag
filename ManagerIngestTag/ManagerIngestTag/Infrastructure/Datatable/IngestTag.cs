using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class IngestTag
    {
        [Key]
        public Guid IngestTagId { get; set; }
        public string IngestCode { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }
        public Position Position { get; set; }

        [ForeignKey("Employee")]
        public Guid cardholderId { get; set; }
        public Employee Employee { get; set; }

    }
}
