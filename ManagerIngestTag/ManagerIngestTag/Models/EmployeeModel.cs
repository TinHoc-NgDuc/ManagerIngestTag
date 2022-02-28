using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Models
{
    public class EmployeeModel
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public Guid ProductionUnitId { get; set; }
        public Guid PositionId { get; set; }
    }
}
