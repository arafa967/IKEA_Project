using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Models.Department
{
    public class DepartmentToReturnDTO
    {

        public int Id { get; set; }
        //public int CreatingBy { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public int LastModificationBy { get; set; }
        //public DateTime LastModifiedOn { get; set; }
        //public bool IsDeleted { get; set; }
        public String Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
