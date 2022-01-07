using Applications.DTO_s;
using Applications.Interfaces;
using Applications.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Company
{
    public class CompanyFixture 
    {
        public CompanyDto CompDto()
        {
            

            return new Mock<CompanyDto>().Object;
        } 
    }
}
