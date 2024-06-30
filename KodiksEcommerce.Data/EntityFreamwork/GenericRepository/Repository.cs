﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KodiksEcommerce.Data.EntityFreamwork.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly Context _context;
        private readonly DbSet<T> _dbSet;

        public Repository(Context context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public T Find(int id)
        {
            return _dbSet.Find(id);
        }
        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }
        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefaultAsync(expression);
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
