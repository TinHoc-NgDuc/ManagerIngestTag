using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngestTag.Models
{
    public class Filter
    {
        public string Query { get; set; }
        public int PageSize { get; set; }
        public int NumberPage { get; set; }
    }
}
