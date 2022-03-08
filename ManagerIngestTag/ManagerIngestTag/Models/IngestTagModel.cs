using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Models
{
    public class IngestTagModel
    {
        public Guid IngestTagId { get; set; }
        public string IngestCode { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }
        public Guid CategoryId { get; set; }
        public Guid cardholderId { get; set; }
        public Guid EmployeeId { get; set; }
    }
    public class IngestTagReturnModel : IngestTagModel
    {
        public string CategoryName { get; set; }
        public string CardholderName { get; set; }

    }
}
