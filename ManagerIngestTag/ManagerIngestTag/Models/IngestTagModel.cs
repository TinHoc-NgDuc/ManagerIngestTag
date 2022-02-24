using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Models
{
    public class IngestTagModel
    {
        public Guid IngestTagId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }

    }
}
