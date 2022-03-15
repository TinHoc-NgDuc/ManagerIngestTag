using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Models
{
    public class TicketIngestModel
    {
        public Guid TicketIngestId { get; set; }
        public string Name { get; set; }
        public string CreateName { get; set; }
        public string TopicName { get; set; }
        public string ProgramName { get; set; }
        public string CameramanName { get; set; }
        public string ProductionName { get; set; }
        public string ReporterName { get; set; }
        public DateTime SaveDocument { get; set; }
        public bool IsReporting { get; set; }
        public bool IsNew { get; set; }
        public bool IsCategory { get; set; }
        public bool IsOtherProgram { get; set; }
        public string StatusIngest { get; set; }
    }
    public class TicketIngestFull : TicketIngestModel
    {
        public string StatusName { get; set; }
        public List<IngestDetailFull> IngestDetailFull { get; set; }
    }
}
