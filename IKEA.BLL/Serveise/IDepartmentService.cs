using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.Models.Department;
using IKEA.DAL.Models.Departmens;

namespace IKEA.BLL.Serveise
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentToReturnDTO> GetAllDeparment();
        DepartmentDetailsToReturnDTO? GetDepartmentById(int id);
        int CreateDepartment(CreatedDepartmentDto departmentDTO);
        int UpdateDeparment(UpdatedDeparmentDTO departmentDTO);
        bool DeleteDepartment(int id);
    }
}
