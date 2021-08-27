using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskProject.Entities.Models
{
    [Table("Company", Schema = "public")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        //[Column(TypeName = "jsonb")]
        public string CompanyDetail { get; set; }
    }
}
