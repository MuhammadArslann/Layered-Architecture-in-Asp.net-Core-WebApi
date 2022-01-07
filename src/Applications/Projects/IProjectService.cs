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
   public interface IProjectService
    {
        IList<ProjectsDto> GetProjects();
        ProjectsDto AddProject(ProjectsDto dto);
        ProjectsDto GetSingleProject(int id);
        ProjectsDto EditProjects(ProjectsDto dto);
        void DeleteProject(int id);

    }
}
