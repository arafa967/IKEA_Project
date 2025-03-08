using System.ComponentModel.DataAnnotations;

namespace IKEA.PL.Models.Departments
{
    public class DepartmentEditViewModel
    {
        [Required(ErrorMessage ="Code is Required !!!")]
        public string Code { get; set; } = null!;
        public String Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
