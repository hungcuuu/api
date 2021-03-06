﻿//using DAL.Models;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly PointOfSaleDBPassioContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(PointOfSaleDBPassioContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public System.Linq.IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
