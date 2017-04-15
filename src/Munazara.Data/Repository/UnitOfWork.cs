using System;
using System.Collections.Generic;
using System.Linq;

namespace Munazara.Data.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private MunazaraContext Context;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork()
        {
            Context = new MunazaraContext();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }
            IGenericRepository<T> repo = new GenericRepository<T>(Context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}