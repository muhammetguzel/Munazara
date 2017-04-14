﻿
using System;
using System.Collections.Generic;
using System.Linq;

namespace Munazara.Infrastructure.Data.Repository
{
    public class UnitOfWork : IDisposable
    {
        private MunazaraContext Context = new MunazaraContext();
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

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
