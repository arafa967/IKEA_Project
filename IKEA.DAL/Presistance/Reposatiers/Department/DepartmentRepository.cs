using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departmens;
using IKEA.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Presistance.Reposatiers.Department
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        public IEnumerable<Depaertment> GetAll(bool withNoTracking = true)
        {
            if (withNoTracking) 
            {

                _dbContext.Depaertments.AsNoTracking().ToList();

            }
            return _dbContext.Depaertments.ToList();
                
        }

        public Depaertment? GetById(int id)
        {
           // var department = _dbContext.Depaertments.Local.FirstOrDefault(D=>D.Id ==id);
           var department = _dbContext.Depaertments.Find(id);
            return department;
        }
        
        public int Add(Depaertment entity)
        {
             _dbContext.Depaertments.Add(entity);
            //AddLocal
            return _dbContext.SaveChanges();
        }

        public int Update(Depaertment entity)
        {
             _dbContext.Depaertments.Update(entity);
            return _dbContext.SaveChanges();
        }
        public int Delete(Depaertment entity)
        {
            _dbContext?.Depaertments.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IQueryable<Depaertment> GetAllAsQuarable()
        {
            return _dbContext.Depaertments;
        }
    }
}
