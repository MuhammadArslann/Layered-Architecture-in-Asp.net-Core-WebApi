using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DTO_s
{
   public class ProjectsDto
    {
       
        public int Id { get; set; }
        [Required]
        
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
       
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }

    }
}
