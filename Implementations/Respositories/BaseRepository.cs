using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using V_Tailoring.Context;
using V_Tailoring.Interfaces.Respositories;
using V_Tailoring.Contracts;
using Microsoft.EntityFrameworkCore;

namespace V_Tailoring.Implementations.Respositories
{
    public class BaseRepository<T> : IRepo<T> where T : class, new()
    {
        protected TailoringContext context;
        public async Task<T> Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            var ans = await context.Set<T>().FirstOrDefaultAsync(expression);
            return ans;
        }
        public async Task<IList<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<bool> Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<IList<T>> GetByExpression(Expression<Func<T, bool>> expression)
        {
            var get = await context.Set<T>().Where(expression).ToListAsync();
            return get;
        }
    }
}
