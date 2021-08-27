using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Dal.Abstract;
using TaskProject.Dal.Concrete.EntityFramework.Context;
using TaskProject.Entities.Models;

namespace TaskProject.Dal.Concrete.EntityFramework.Repository
{
    public class EfUserRepository : EfGenericRepository<User>, IUserRepository
    {
        public List<UserDto> GetUsersDetails()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from r in context.User
                             join c in context.Company on r.Id equals c.Id
                             join cu in context.Role on r.Id equals cu.Id

                             select new UserDto
                             {
                                 UserId = r.Id,
                                 RoleId = cu.Id,
                                 RoleName = cu.RoleName,
                                 CompanyDetail = c.CompanyDetail
                             };

                return result.ToList();
            }
        }
    }
}
