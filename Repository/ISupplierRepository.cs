using Day06.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repository
{
    internal interface ISupplierRepository
    {
        IEnumerator<Supplier> FindAll();
        Supplier FindById(int id);
        void Insert(Supplier supplier);
        void Update(int id, Supplier supplier);
        void Delete(int id);
    }
}
