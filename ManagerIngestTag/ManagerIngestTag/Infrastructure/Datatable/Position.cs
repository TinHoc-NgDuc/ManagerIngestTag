using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class Position
    {
        [Key]
        public Guid PositionId { get; set; }
        public string Name { get; set; }
    }
}
