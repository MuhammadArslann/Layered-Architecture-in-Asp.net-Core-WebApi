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
   public class ProjectService : IProjectService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IMapper _mapper;
        public ProjectService(IMapper mapper,ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _mapper = mapper;
        }

        public ProjectsDto AddProject(ProjectsDto dto)
        {
            var proj = _mapper.Map<Projects>(dto);
            _applicationContext.Projects.Add(proj);
            _applicationContext.SaveChanges();
            dto.Id = proj.Id;
            return dto;
        }

        public void DeleteProject(int id)
        {
            var existingProj = _applicationContext.Projects.FirstOrDefault(x => x.Id.Equals(id));
            if (existingProj != null)
            {
                _applicationContext.Remove(existingProj);
                _applicationContext.SaveChanges();
            }
            throw new Exception("Project not found.");
        }
        public ProjectsDto EditProjects(ProjectsDto dto)
        {
            var existingProj = _applicationContext.Projects.FirstOrDefault(x => x.Id.Equals(dto.Id));
            if (existingProj != null)
            {
                existingProj.Name = dto.Name;
                existingProj.Code = dto.Code;
                existingProj.Description = dto.Description;
                _applicationContext.Update(existingProj);
                _applicationContext.SaveChanges();
                existingProj = _applicationContext.Projects.FirstOrDefault(x => x.Id.Equals(dto.Id));
            }
            return dto;
        }
        public IList<ProjectsDto> GetProjects()
        {
            var result = _mapper.Map<IList<ProjectsDto>>(_applicationContext.Projects.ToList()); 
            return result;
        }
        //.Where(x=>x.CompanyId.Equals(id))
        public ProjectsDto GetSingleProject(int id)
        {
            var singleProj = _mapper.Map<ProjectsDto>(_applicationContext.Projects.FirstOrDefault(x => x.Id.Equals(id)));
            if (singleProj != null)
            {
                return singleProj;
            }
            throw new Exception("Project not found!");
        }
    }
}
