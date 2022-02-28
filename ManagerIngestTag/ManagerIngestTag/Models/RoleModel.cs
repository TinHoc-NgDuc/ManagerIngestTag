using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerIngest.Models
{
    public class RoleModel
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
    }
}
