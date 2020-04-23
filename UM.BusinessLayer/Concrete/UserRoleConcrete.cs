using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UM.BusinessLayer.Abstract;
using UM.BusinessLayer.Factory;
using UM.DataAccessLayer.Abstract;
using UM.EntitiesLayer;

namespace UM.BusinessLayer.Concrete
{
    public class UserRoleConcrete : IDataService<userrole>
    {
        IDataAccessDal<userrole> _idataaccessdal;
        public UserRoleConcrete()
        {
            _idataaccessdal = DataAccessFactory.GetUserRoleDataAccessObj();
        }
        public void Create(userrole entity)
        {
            _idataaccessdal.Create(entity);
        }

        public userrole Get(int id)
        {
            return _idataaccessdal.Get(id);
        }

        public IEnumerable<userrole> GetAll()
        {
            return _idataaccessdal.GetAll();
        }

        public string[] GetRole(string username)
        {
            var data = _idataaccessdal.GetFilter(x => x.user.First_Name == username).ToList();
            string[] result = new string[data.Count];
            int i = 0;
            string s = string.Empty;
            foreach (var item in data)
            {
                s = item.role.Role_Name.ToString();
                result[i] = s;
                i++;
            }
            
            return result;
        }

        public IEnumerable<userrole> GetFilter(Expression<Func<userrole, bool>> expression)
        {
            return _idataaccessdal.GetFilter(expression);
        }

        public void Remove(int id)
        {
            _idataaccessdal.Remove(id);
        }

        public void Update(userrole entity)
        {
            _idataaccessdal.Update(entity);
        }
    }
}
