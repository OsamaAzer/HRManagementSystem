using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BaseRepository<T>(AppDbContext context) : IBaseRepository<T> where T : class
    {
        public async Task<T> Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return entity;      
        }

        public async Task<IEnumerable<T>> AddRange(IEnumerable<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public void Attach(T entity)
        {
            context.Set<T>().Attach(entity);
        }

        public void AttachRange(IEnumerable<T> entities)
        {
            context.AttachRange(entities);
        }

        public async Task<int> Count(Expression<Func<T, bool>>? criteria)
        {
            if(criteria == null)
                return await context.Set<T>().CountAsync();

            return await context.Set<T>().CountAsync(criteria);
        }

        public T Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return entity;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

        public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> criteria)
        {
            return await context.Set<T>().Where(criteria).ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> criteria, string[]? includes = null)
        {
            IQueryable<T> query = context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(criteria).ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(string[]? includes = null)
        {
            IQueryable<T> query = context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {

            return await context.Set<T>().FindAsync(id);
        }

        public T Update(T entity)
        {
            context.Set<T>().Update(entity);
            return entity;
        }
    }
}
