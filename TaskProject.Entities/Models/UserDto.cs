using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Entities.Models
{
    public class UserDto
    {
        public int UserId { get; set; }  
        public int  RoleId { get; set; }
        public string RoleName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyDetail { get; set; }
        public string UserDetail { get; set; }
 

    }
}
