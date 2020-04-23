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
    public class UserConcrete : IDataService<user>
    {
        IDataAccessDal<user> _idataaccessdal;
        public UserConcrete()
        {
            _idataaccessdal = DataAccessFactory.GetUserDataAccessObj();
        }
        public void Create(user entity)
        {
            _idataaccessdal.Create(entity);
        }

        public user Get(int id)
        {
           return _idataaccessdal.Get(id);
        }

        public IEnumerable<user> GetAll()
        {
            return _idataaccessdal.GetAll();
        }

        public IEnumerable<user> GetFilter(Expression<Func<user, bool>> expression)
        {
            return _idataaccessdal.GetFilter(expression);
        }

        public void Remove(int id)
        {
            _idataaccessdal.Remove(id);
        }

        public void Update(user entity)
        {
            _idataaccessdal.Update(entity);
        }
    }
}
