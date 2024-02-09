using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EmployeeManagementAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AppDBContext _dbContext;
        private DbSet<T> entities = null;
        public Repository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<T>();
        }
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<T> Add(T entity)
        {
            var result=await entities.AddAsync(entity);
            await Save();
            return result.Entity;
        }
        public async Task Delete(Expression<Func<T, bool>> filter)
        {
            var entity = await GetSingle(filter);
            if (entity != null)
            {
                entities.Remove(entity);
                await Save();
            }
        }
        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] children)
        {
            var query = entities.AsQueryable();
            foreach (var include in children)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }
        public async Task<T> GetSingle(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] children)
        {
            var query= entities.AsQueryable().Where(filter);
            foreach(var include in children)
            {
                query=query.Include(include);
            }
            return await query.FirstOrDefaultAsync();
        }
        public async Task<T> UpdateEntity(T entity)
        {
            await Save();
            return entity;            
        }

        public async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> filter)
        {
            return await entities.AsQueryable().Where(filter).ToListAsync();
        }
    }
}
