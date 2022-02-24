using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class ProgramShow
    {
        [Key]
        public Guid PropgramShowId { get; set; }
        public string Name { get; set; }
    }
}
