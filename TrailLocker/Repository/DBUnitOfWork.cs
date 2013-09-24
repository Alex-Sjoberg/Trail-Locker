using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailLocker.Models;
using System.Data.Entity;

namespace TrailLocker.Repository
{
    public class DBUnitOfWork : IUnitOfWork
    {
        protected TrailLockerEntities Database = new TrailLockerEntities();

        public void Dispose()
        {
            Database = null;
        }

        public void Commit()
        {
            Database.SaveChanges();
        }


        public void Attach<T>(T obj, bool setToChanged = false) where T : class
        {
            Add(obj);
        }

        public void Add<T>(T obj) where T : class
        {
            var table = GetDatabaseTable<T>();

            table.Add(obj);
        }

        public IQueryable<T> Get<T>() where T : class
        {
            var table = GetDatabaseTable<T>();

            return table.AsQueryable();
        }
            
        public bool Remove<T>(T item) where T : class
        {
            var table = GetDatabaseTable<T>();

            return table.Remove(item);
        }


        protected ICollection<T> GetDatabaseTable<T>() where T : class
        {
            List<T> table = Database.Set<T>().ToList();

           return table as ICollection<T>;
            
            /*
            if (!Database.Any(x => x.Key == key))
            {
                table = new Collection<T>();
                Database.Add(key, table);
            }
            else
            {
                table = Database[key] as Collection<T>;
            }
            return table;
            */
        }


    }
}
