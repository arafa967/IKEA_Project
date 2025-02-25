using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Departmens
{
    public class Depaertment : ModelBase
    {
        public String Name { get; set; } = null!;
        public  string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
