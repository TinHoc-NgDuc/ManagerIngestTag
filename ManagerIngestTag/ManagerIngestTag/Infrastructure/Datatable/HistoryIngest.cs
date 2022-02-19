using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class HistoryIngest
    {
        public Guid HistoryIngestId { get; set; }
        public Guid IngestId { get; set; }
        public string Action { get; set; }
        public string NameAction { get; set; }
        public DateTime TimeAction { get; set; }
    }
}
