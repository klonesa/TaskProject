using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Entities.Models;

namespace TaskProject.Interfaces
{
    public interface IUserService : IGenericService<User>
    {
        //List<UserDto> GetUsersDetails();
    }
}
