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
    public class CompanyManager :  GenericManager<Company>, ICompanyService
    {
        ICompanyRepository companyRepository;

        public CompanyManager(ICompanyRepository companyRepository) : base(companyRepository)
        {
            this.companyRepository = companyRepository;
        }
    }
}
