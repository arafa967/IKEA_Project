using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departmens;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Presistance.Reposatiers._Generic;

namespace IKEA.DAL.Presistance.Reposatiers.Employees
{
    internal interface IEmployeeRepository : IGenericRepository<Employee>
    {

    }

}