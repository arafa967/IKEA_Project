using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Models.Department
{
     public class UpdatedDeparmentDTO
    {
        public int Id { get; set; }
        public String Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreatedDate { get; set; }
    }
}
