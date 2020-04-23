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
    public class EFUserRoleConcrete : IDataAccessDal<userrole>
    {

        public userrole _userrole
        {
            get { return _userrole; }
            set
            {
                value.user.Password = "***";
                _userrole = value;
            }
        }


        public void Create(userrole entity)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                DB.userroles.Add(entity);
                DB.SaveChanges();
            }
        }

        public userrole Get(int id)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                _userrole = DB.userroles.Find(id);
                return _userrole;
            }
        }


        public IEnumerable<userrole> GetAll()
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                return DB.userroles.ToList();

            }
        }

        public IEnumerable<userrole> GetFilter(Expression<Func<userrole, bool>> expression)
        {
            usermanagerDBEntities DB = new usermanagerDBEntities();
            return DB.userroles.Where(expression).ToList();
        }

        public void Remove(int id)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                DB.userroles.Remove(DB.userroles.Find(id));
            }
        }

        public void Update(userrole entity)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                DB.userroles.Attach(entity);
                DB.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
            }
        }
    }
}
