using Applications.DTO_s;
using Applications.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
    
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            return Ok(_companyService.GetCompanies());
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSingleCompany(int id)
        {

            return Ok(_companyService.GetSingleCompany(id));
        }
        [HttpPost]
        public IActionResult AddCompany(CompanyDto company)
        {
           return Ok(_companyService.AddCompnay(company));
            
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCompany(int id)
        {
          _companyService.DeleteCompany(id);
            return Ok("User Deleted!");
        }
        [HttpPatch]
        [Route("{id}")]
        public IActionResult EditCompany(int id, CompanyDto company)
        {
            var singleComp = _companyService.GetSingleCompany(id);
            if(singleComp != null)
            {
                singleComp.CompanyId = company.CompanyId;
                _companyService.EditCompany(company);
            }
            return Ok(company);
        }
    }
}
