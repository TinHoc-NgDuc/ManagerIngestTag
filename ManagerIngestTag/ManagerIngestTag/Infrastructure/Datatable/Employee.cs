using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public ProductionUnit ProductionUnit { get; set; }
        public Position Position { get; set; }
    }
}
