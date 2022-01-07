using Applications.DTO_s;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Projects
{
   public class ProjectsFixture
    {
        public ProjectsDto ProjDto()
        {
            return new Mock<ProjectsDto>().Object;
            
        }   
    }
}
