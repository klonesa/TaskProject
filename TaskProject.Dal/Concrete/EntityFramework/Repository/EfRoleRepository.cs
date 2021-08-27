using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Dal.Abstract;
using TaskProject.Entities.Models;

namespace TaskProject.Dal.Concrete.EntityFramework.Repository
{
    public class EfRoleRepository : EfGenericRepository<Role>, IRoleRepository
    {
    }
}
