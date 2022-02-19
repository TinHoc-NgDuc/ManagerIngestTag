using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerIngest.Infrastructure.Datatable
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }
        public string Name { get; set; }
    }
}
