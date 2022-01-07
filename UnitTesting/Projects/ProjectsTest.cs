using Applications.DTO_s;
using Applications.Interfaces;
using Moq;
using Persistance.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTesting.Projects
{
    public class ProjectsTest : TestBase
    {
        private readonly IProjectService _projectService;
        private readonly ApplicationContext _context;
        public ProjectsTest(Fixture fixture) : base(fixture)
        {

            _projectService = Services.GetService<IProjectService>();
            _context = Services.GetService<ApplicationContext>();
        }
        [Trait("Category", "Project")]
        [Theory]
        [InlineData("Alternate", "12", "This is description")]
        public void AddProject_Test(string name, string code, string description)
        {
            var mock = new ProjectsDto { Name = name, Code = code, Description = description };
            ProjectsDto result = _projectService.AddProject(mock);
            var expect = _context.Projects.FirstOrDefault(x => x.Id.Equals(result.Id));
            Assert.NotNull(result);
            Assert.Equal(result.Name, expect.Name);
            Assert.Equal(result.Code, expect.Code);
            Assert.Equal(result.Description, expect.Description);
        }
        [Trait("Category", "Project")]
        [Theory]
        [InlineData(1)]
        public void DeleteProject_test(int id)
        {
            var ex = _context.Projects.FirstOrDefault(x => x.Id.Equals(id));
            _projectService.DeleteProject(id);
            Assert.Null(ex);
        }
        [Trait("Category", "Project")]
        [Theory]
        [InlineData("Alternate1", "121", "This is description1")]
        public void EditCompany_test(string name, string code, string description)
        {
            var mock = new ProjectsDto() { Id = SeedData.Id, Name = name, Code = code, Description = description };
            ProjectsDto result = _projectService.EditProjects(mock);
            var edit = _context.Projects.FirstOrDefault(x => x.Id.Equals(result.Id));
            ProjectsDto expect = _projectService.GetSingleProject(edit.Id);
            Assert.NotNull(result);
            Assert.Equal(result.Name,expect.Name);
            Assert.Equal(result.Code, expect.Code);
            Assert.Equal(result.Description, expect.Description);
        }

    }
}
