using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departmens;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Presistance.Data
{
    public class ApplicationDbContext :DbContext 
    {
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=IKEAG02C43;Trusted_Connection= true;TrustServercertificate=true;");
        //}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        #region  Dbset
        public DbSet<Depaertment> Depaertments { get; set; }
        #endregion
    }
}
