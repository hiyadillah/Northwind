using Day06.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repository
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly AdoDbContext _adoDbContext;
        protected readonly DapperDbContext _dapperDbContext;
        // inject with adodbcontext
        public RepositoryBase(AdoDbContext _adoDbContext, DapperDbContext dapperDbContext)
        {
            this._adoDbContext = _adoDbContext;
            _dapperDbContext = dapperDbContext;
        }

        public virtual void Delete(dynamic id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindById(dynamic id)
        {
            throw new NotImplementedException();
        }

        public virtual void Save(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(dynamic id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
