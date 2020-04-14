using DAL.Repositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PointOfSaleDBPassioContext _context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public UnitOfWork(PointOfSaleDBPassioContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IRepositoryBase<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                repositories.Add(type, repositoryInstance);
            }
            return (IRepositoryBase<T>)repositories[type];
        }
    }
}
