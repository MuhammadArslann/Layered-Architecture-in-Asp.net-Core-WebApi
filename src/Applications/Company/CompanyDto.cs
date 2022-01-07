using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DTO_s
{
   public class CompanyDto
    {
       
        public int CompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        public int Phone { get; set; }
        public ICollection<Projects> Projects { get; set; }
    }
}
