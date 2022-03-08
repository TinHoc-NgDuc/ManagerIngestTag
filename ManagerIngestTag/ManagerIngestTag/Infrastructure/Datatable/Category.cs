using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerIngestTag.Infrastructure.Datatable
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
