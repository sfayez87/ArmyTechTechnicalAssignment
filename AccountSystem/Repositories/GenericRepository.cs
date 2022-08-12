using AccountSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AccountSystem.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AccountModel context = new AccountModel();
        public T Add(T row)
        {
            context.Entry<T>(row).State = EntityState.Added;
            context.SaveChanges();
            return row;
        }

        public void Delete(T row)
        {
            context.Entry<T>(row).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> rows)
        {
            context.Set<T>().RemoveRange(rows);
            context.SaveChanges();
        }

        public T Edit(T row)
        {
            context.Entry<T>(row).State = EntityState.Modified;
            context.SaveChanges();
            return row;
        }

        public T Get(long id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }
    }
}