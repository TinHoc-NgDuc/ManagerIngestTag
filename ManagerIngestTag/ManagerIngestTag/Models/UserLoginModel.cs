using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Models
{
    public class UserLoginModel
    {
        public Guid UserLoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid PositionId { get; set; }
    }
}
