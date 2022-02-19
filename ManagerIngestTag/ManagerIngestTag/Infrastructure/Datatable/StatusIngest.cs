using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class StatusIngest
    {
        [Key]
        public Guid StatusIngestId { get; set; }
        public string Name { get; set; }
    }
}
