using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Models
{
    public class ProductionUnitModel
    {
        public Guid ProductionUnitId { get; set; }
        public string Name { get; set; }
    }
}
