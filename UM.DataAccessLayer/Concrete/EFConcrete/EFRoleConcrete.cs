using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UM.DataAccessLayer.Abstract;
using UM.EntitiesLayer;

namespace UM.DataAccessLayer.Concrete.EFConcrete
{
    public class EFRoleConcrete:IDataAccessDal<role>
    {
        public void Create(role entity)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                DB.roles.Add(entity);
                DB.SaveChanges();
            }
        }

        public role Get(int id)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                return DB.roles.Find(id);
            }
        }

        public IEnumerable<role> GetAll()
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                return DB.roles.ToList();
                
            }
        }

        public IEnumerable<role> GetFilter(Expression<Func<role, bool>> expression)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                return DB.roles.Where(expression).ToList();
                
            }
        }

        public void Remove(int id)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                DB.roles.Remove(DB.roles.Find(id));
            }
        }

        public void Update(role entity)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                DB.roles.Attach(entity);
                DB.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
            }
        }
    }
}
