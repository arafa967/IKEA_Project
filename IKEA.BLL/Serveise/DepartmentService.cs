using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.Models.Department;
using IKEA.DAL.Models.Departmens;
using IKEA.DAL.Presistance.Reposatiers.Department;
using Microsoft.EntityFrameworkCore;

namespace IKEA.BLL.Serveise
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public int CreateDepartment(CreatedDepartmentDto departmentDto)
        {
            var Createddepartment = new Depaertment()
            {
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreatedDate = departmentDto.CreatedDate,
                CreatingBy = 1,
                LastModificationBy = 1,
                LastModifiedOn = DateTime.UtcNow,
                //CreatedOn = DateTime.UtcNow,    
            };
            return _departmentRepository.Add(Createddepartment);
        }

        public bool DeleteDepartment(int id)
        {
            var department  = _departmentRepository.GetById(id);
            if (department is not null)
            {
                return _departmentRepository.Delete(department) >0;
            }
            return false;
        }

        public IEnumerable<DepartmentToReturnDTO> GetAllDeparment()
        {
            var departments = _departmentRepository.GetAllAsQuarable().Select(department => new DepartmentToReturnDTO

            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
               // Description = department.Description,
                CreatedDate = department.CreatedDate

            }).AsNoTracking().ToList();
            return departments;

            
        }

        public DepartmentDetailsToReturnDTO? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            if(department is not null)
            {
                return new DepartmentDetailsToReturnDTO
                {
                    Id = department.Id,
                    Name = department.Name,
                    Code = department.Code,
                    Description = department.Description,
                    CreatedDate = department.CreatedDate,
                    CreatingBy = department.CreatingBy,
                    CreatedOn = department.CreatedOn,
                    LastModificationBy = department.LastModificationBy,
                    LastModifiedOn = department.LastModifiedOn

                };
            }return null;
            
        }

        public int UpdateDeparment(UpdatedDeparmentDTO departmentDto)
        {
            var Updateddepartment = new Depaertment()
            {
                Id =departmentDto.Id,
                Code = departmentDto.Code,  
                Name = departmentDto.Name,
                Description = departmentDto.Description,    
                CreatedDate = departmentDto.CreatedDate,    
                LastModificationBy = 1,
                LastModifiedOn = DateTime.UtcNow,
            };
            return _departmentRepository.Update(Updateddepartment);
        }
    }
}
