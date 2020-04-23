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
    public class RoleConcrete : IDataService<role>
    {
        IDataAccessDal<role> _idataaccessdal;
        public RoleConcrete()
        {
            _idataaccessdal = DataAccessFactory.GetRoleDataAccessObj();
        }
        public void Create(role entity)
        {
            _idataaccessdal.Create(entity);
        }

        public role Get(int id)
        {
            return _idataaccessdal.Get(id);
        }

        public IEnumerable<role> GetAll()
        {
            return _idataaccessdal.GetAll();
        }

        public IEnumerable<role> GetFilter(Expression<Func<role, bool>> expression)
        {
            return _idataaccessdal.GetFilter(expression);
        }

        public void Remove(int id)
        {
            _idataaccessdal.Remove(id);
        }

        public void Update(role entity)
        {
            _idataaccessdal.Update(entity);
        }
    }
}
