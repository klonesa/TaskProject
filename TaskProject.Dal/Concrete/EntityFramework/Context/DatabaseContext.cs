using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskProject.Entities.Models;

namespace TaskProject.Dal.Concrete.EntityFramework.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            :base("name=DatabaseContext")
        {

        }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        private void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
