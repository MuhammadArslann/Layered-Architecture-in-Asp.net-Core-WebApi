using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
   public class ApplicationContext: DbContext
   {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
        }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projects>().HasOne<Company>(s => s.Company).WithMany(g => g.Projects).HasForeignKey(x => x.CompanyId);
        }
    }
}
