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
    public class EFUserConcrete : IDataAccessDal<user>
    {
        public user User
        {
            get { return User; }
            set 
            {
                value.Password = "***";
                User = value; 
            }
        }

        public void Create(user entity)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                DB.users.Add(entity);
                DB.SaveChanges();
            }
        }

        public user Get(int id)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                User = DB.users.Find(id);
                return User;
            }
        }

        public IEnumerable<user> GetAll()
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                return DB.users.ToList();
                
            }
        }

        public IEnumerable<user> GetFilter(Expression<Func<user, bool>> expression)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                return DB.users.Where(expression).ToList();
                
            }
        }

        public void Remove(int id)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                DB.users.Remove(DB.users.Find(id));
            }
        }

        public void Update(user entity)
        {
            using (usermanagerDBEntities DB = new usermanagerDBEntities())
            {
                DB.users.Attach(entity);
                DB.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
            }
        }
    }
}
