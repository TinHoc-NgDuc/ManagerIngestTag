using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class Topic
    {
        public Guid TopicId { get; set; }
        public string Name { get; set; }
        public string ProgramName { get; set; }
        public string CameramanName { get; set; }
        public string ProductionName { get; set; }
        public string ReporterName { get; set; }
        public string CreateName { get; set; }
        public bool IsReporting { get; set; }
        public bool IsNew { get; set; }
        public bool IsCategory { get; set; }
        public bool IsOtherProgram { get; set; }
    }
}
