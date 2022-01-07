using Applications.DTO_s;
using Applications.Repositories;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Interfaces
{
   public interface ICompanyService
    {
        IList<CompanyDto> GetCompanies();
        CompanyDto AddCompnay(CompanyDto company);
        CompanyDto EditCompany(CompanyDto company);
        void DeleteCompany(int id);

        CompanyDto GetSingleCompany(int id);
    }
}
