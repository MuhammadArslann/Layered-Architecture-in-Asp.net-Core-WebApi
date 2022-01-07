using Applications.DTO_s;
using Applications.Interfaces;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using System.Linq;

namespace UnitTesting.Company
{
    [Collection("Company")]
    public class CompanyTest : TestBase
    {
        private readonly ICompanyService _companyService;
        private readonly ApplicationContext _context;
        public CompanyTest(Fixture fixture) : base(fixture)
        {

            _companyService = Services.GetService<ICompanyService>();
            _context = Services.GetService<ApplicationContext>();
        }
        [Trait("Category", "Company")]
        [Theory]
        [InlineData ( "Test",  "test", 1)]
        public void AddCompany_Test( string name, string website, int phone)
        {
            var mock = new CompanyDto() {  Name = name, Website = website, Phone = phone };
           
            CompanyDto result = _companyService.AddCompnay(mock);
            var expect = _context.Company.FirstOrDefault(x => x.CompanyId.Equals(result.CompanyId));
            Assert.NotNull(result);
            Assert.Equal(result.CompanyId, expect.CompanyId);
            Assert.Equal(result.Name, expect.Name);
            Assert.Equal(result.Phone, expect.Phone);
            Assert.Equal(result.Website, expect.Website);
            Assert.Equal(result.CompanyId, expect.CompanyId);
        }

        [Trait("Category", "Company")]
        [Fact]
        public void DeleteCompany_test()
        {
            var ex = _context.Company.FirstOrDefault(x => x.CompanyId.Equals(SeedData.CompanyId));
            Assert.NotNull(ex);
            _companyService.DeleteCompany(SeedData.CompanyId);
            ex = _context.Company.FirstOrDefault(x => x.CompanyId.Equals(SeedData.CompanyId));
            Assert.Null(ex);
        }
        [Trait("Category", "Company")]
        [Theory]
        [InlineData("Test1", "test2", 13)]
        public void EditCompany_test(string name, string website, int phone)
        {
            var mock = new CompanyDto() { CompanyId = SeedData.CompanyId, Name = name, Website = website, Phone = phone };
            CompanyDto result = _companyService.EditCompany(mock);
            var edit = _context.Company.FirstOrDefault(x =>  x.CompanyId.Equals(result.CompanyId) );
            CompanyDto expect = _companyService.GetSingleCompany(edit.CompanyId);
            Assert.NotNull(result);
            Assert.Equal(result.CompanyId, expect.CompanyId);
            Assert.Equal(result.Name, expect.Name);
            Assert.Equal(result.Phone, expect.Phone);
            Assert.Equal(result.Website, expect.Website);
            Assert.Equal(result.CompanyId, expect.CompanyId);
        }
    }
}
