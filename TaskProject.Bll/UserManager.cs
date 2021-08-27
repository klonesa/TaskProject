using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Dal.Abstract;
using TaskProject.Entities.Models;
using TaskProject.Interfaces;

namespace TaskProject.Bll
{
    public class UserManager : GenericManager<User>, IUserService
    {
        IUserRepository userRepository;

        public UserManager(IUserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

        //public List<UserDto> GetUsersDetails()
        //{
        //    return List<UserDto>(userRepository.GetUsersDetails());
        //}

    }
}
