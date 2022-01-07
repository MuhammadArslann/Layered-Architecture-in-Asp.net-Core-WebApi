using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
   public class Projects 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
