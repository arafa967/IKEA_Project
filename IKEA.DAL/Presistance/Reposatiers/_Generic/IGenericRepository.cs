using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models;
using IKEA.DAL.Models. Ts;

namespace IKEA.DAL.Presistance.Reposatiers._Generic
{
    public interface IGenericRepository<T>where T : ModelBase
    {

        IEnumerable< T> GetAll(bool withNoTracking = true);
         T? GetById(int id);
        int Add( T entity);
        int Update( T entity);
        int Delete( T entity);
    }
}
