using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UM.BusinessLayer.Abstract
{
    public interface IDataService<T>where T :class
    {
        void Create(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetFilter(Expression<Func<T, bool>> expression);
        T Get(int id);
        void Remove(int id);
        void Update(T entity);
    }
}
