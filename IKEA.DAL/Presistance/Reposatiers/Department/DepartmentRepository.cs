using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departmens;
using IKEA.DAL.Presistance.Data;
using IKEA.DAL.Presistance.Reposatiers._Generic;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Presistance.Reposatiers.Department
{
    internal class DepartmentRepository :GenericRepository<Depaertment>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
       
    }
}
