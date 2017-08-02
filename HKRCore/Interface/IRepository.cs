using HKRCore.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HKRCore.Interface
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
