using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.DataAccessLayer.Abstract;
using UM.DataAccessLayer.Concrete.EFConcrete;
using UM.EntitiesLayer;

namespace UM.BusinessLayer.Factory
{
    public class DataAccessFactory
    {
        public static IDataAccessDal<user> GetUserDataAccessObj()
        {
            return new EFUserConcrete();
        }
        public static IDataAccessDal<userrole> GetUserRoleDataAccessObj()
        {
            return new EFUserRoleConcrete();
        }
        public static IDataAccessDal<role> GetRoleDataAccessObj()
        {
            return new EFRoleConcrete();
        }
    }
}
