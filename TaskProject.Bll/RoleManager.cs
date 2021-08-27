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
    public class RoleManager : GenericManager<Role>, IRoleService
    {
        IRoleRepository roleRepository;

        public RoleManager(IRoleRepository roleRepository) : base(roleRepository)
        {
            this.roleRepository = roleRepository;
        }
    }
}
