using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Data.Repositories
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        void Add(List<T> entities);
        void Update(T entity);
    }

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly BriskContext DB;

        /// <summary>
        /// Provides possibility to inject existing DbContext in order to maintain the same UnitOfWork
        /// If DbContext is not injected, it creates a new one
        /// </summary>
        /// <param name="db">DbContext</param>
        public BaseRepository(BriskContext db = null)
        {
            if (db == null)
            {
                db = new BriskContext();
            }
            DB = db;
        }

        public void Add(T entity)
        {
            DB.Set<T>().Add(entity);
            DB.SaveChanges();
        }

        public void Add(List<T> entities)
        {
            DB.Set<T>().AddRange(entities);
            DB.SaveChanges();
        }

        public void Update(T entity)
        {
            var objectStateManager = ((IObjectContextAdapter)DB).ObjectContext.ObjectStateManager;
            if (objectStateManager.GetObjectStateEntry(entity).State == EntityState.Detached)
            {
                throw new InvalidOperationException("Trying to update a detached entity!");
            }
            DB.SaveChanges();
        }
    }
}