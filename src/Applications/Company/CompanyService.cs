using Applications.DTO_s;
using Applications.Interfaces;
using AutoMapper;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Repositories
{
   public class CompanyService : ICompanyService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IMapper _mapper;
        public CompanyService(IMapper mapper,ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _mapper = mapper;
        }
        public CompanyDto AddCompnay(CompanyDto dto)
        {
            var proj = _mapper.Map<Company>(dto);
            _applicationContext.Add(proj);
            _applicationContext.SaveChanges();
            dto.CompanyId = proj.CompanyId;
            return dto;
        }
        public void DeleteCompany(int id)
        {
            var model = _applicationContext.Company.FirstOrDefault(x => x.CompanyId.Equals(id));
            if (model != null)
            {
                _applicationContext.Remove(model);
                _applicationContext.SaveChanges();

            }
            throw new Exception("Company not found.");
        }
        public CompanyDto EditCompany(CompanyDto company)
        {
            var existingComp = _applicationContext.Company.FirstOrDefault(x => x.CompanyId.Equals(company.CompanyId));
            if (existingComp != null)
            {
                existingComp.Name = company.Name;
                existingComp.Phone = company.Phone;
                existingComp.Website = company.Website;
                _applicationContext.Update(existingComp);
                _applicationContext.SaveChanges();
                existingComp = _applicationContext.Company.FirstOrDefault(x => x.CompanyId.Equals(company.CompanyId));
            }
            return company;
        }
        public IList<CompanyDto> GetCompanies()
        {
            var result = _mapper.Map<IList<CompanyDto>>(_applicationContext.Company.ToList());
            return result;
        }
        public CompanyDto GetSingleCompany(int id)
        {
            //Include(a => a.Projects).Where(x => x.CompanyId.Equals(id)).
            var singleComp = _mapper.Map<CompanyDto>(_applicationContext.Company.FirstOrDefault(x => x.CompanyId.Equals(id)));
            if (singleComp == null) throw new Exception("Company not found.");
            return singleComp;
        }
   }
}
