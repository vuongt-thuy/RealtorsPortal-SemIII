using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Respositories
{
    interface IRespository<T>
    {
        IEnumerable<T> GetAll();
        T GetOne(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
        T FindById(object id);
        bool Create(T t);
        T SaveObject(T t);
        bool Update(T t);
        bool Delete(object id);
        bool Remove(T t);
        bool CheckDuplicate(Expression<Func<T, bool>> predicate);
    }
}
