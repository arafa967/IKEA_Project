using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departmens; 
namespace IKEA.DAL.Presistance.Reposatiers.Department
{
    public interface IDepartmentRepository
    {
        IEnumerable<Depaertment>GetAll(bool withNoTracking =true);
        IQueryable<Depaertment> GetAllAsQuarable();
        Depaertment? GetById(int id);
        int Add (Depaertment entity);
        int Update (Depaertment entity);
        int Delete (Depaertment entity );

    }
}
