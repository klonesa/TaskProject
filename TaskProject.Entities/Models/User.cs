using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Entities.Models
{
    [Table("User", Schema = "public")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
        //jsonb
        public string UserDetail { get; set; }
        //public Company companyDet { get; set; }  
    }
}
