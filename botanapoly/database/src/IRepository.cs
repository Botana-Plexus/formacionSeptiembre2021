using System;
using System.Collections.Generic;

namespace database{
    //TODO: switch to ICollection instead of using list?
    public interface IRepository<T, ID>{
        T saveOrUpdate(T entity);
        void delete(T entity);
        long count();
        bool exists(ID id);
        bool exists(T entity);

        T find(ID id);
        List<T> findAll();
        List<T> findAll(Func<T, bool> filter);
    }
}