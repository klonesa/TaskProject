using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TaskProject.Bll;
using TaskProject.Dal.Concrete.EntityFramework.Repository;
using TaskProject.Interfaces;

namespace TaskProject.MvcUI.App_Start
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;
        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBllBinds();
        }

        private void AddBllBinds()
        {
            this.kernel.Bind<IRoleService>().To<RoleManager>().WithConstructorArgument("roleRepository", new EfRoleRepository());
            this.kernel.Bind<ICompanyService>().To<CompanyManager>().WithConstructorArgument("companyRepository", new EfCompanyRepository());
            this.kernel.Bind<IUserService>().To<UserManager>().WithConstructorArgument("userRepository", new EfUserRepository());
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }
    } 
}