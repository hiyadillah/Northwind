using Day06.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repository
{
    internal interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindById(dynamic id);
        void Save (T entity);
        void Update(dynamic id,T entity);
        void Delete (dynamic id);
    }
}
