using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.Repositories
{
    interface IGenericRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        T Get(long id);
        T Add(T row);
        T Edit(T row);
        void Delete(T row);
        void DeleteRange(IEnumerable<T> rows);

    }
}
