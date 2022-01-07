using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
   public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Website { get; set; }
        [Required]
        public int Phone { get; set; }
        public ICollection<Projects> Projects { get; set; }
    }
}
