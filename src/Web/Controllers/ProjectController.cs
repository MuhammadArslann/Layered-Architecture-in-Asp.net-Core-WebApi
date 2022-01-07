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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            return Ok(_projectService.GetProjects());
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSingleProj(int id)
        {
            return Ok(_projectService.GetSingleProject(id));}
        [HttpPost]
        public IActionResult AddProject(ProjectsDto projects)
        {
            return Ok(_projectService.AddProject(projects));
           
        }
        [HttpPatch]
        [Route("{id}")]
        public IActionResult EditProject(int id, ProjectsDto project)
        {
            var singleProj = _projectService.GetSingleProject(id);
            if (singleProj != null)
            {
              _projectService.EditProjects(project);
            }
            return Ok(project);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var singleComp = _projectService.GetSingleProject(id);
            if (singleComp != null)
            {
                _projectService.DeleteProject(singleComp.CompanyId);
                return Ok("Project Deleted!");
            }
            return NotFound("Project not found!");
        }







    }
}
