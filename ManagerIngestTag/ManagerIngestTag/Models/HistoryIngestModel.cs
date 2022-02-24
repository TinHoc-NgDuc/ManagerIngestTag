using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Models
{
    public class HistoryIngestModel
    {
        public Guid HistoryIngestId { get; set; }
        public string Action { get; set; }
        public string NameAction { get; set; }
        public DateTime TimeAction { get; set; }
        public Guid IngestTagId { get; set; }
    }
}
