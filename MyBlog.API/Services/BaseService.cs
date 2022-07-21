using Microsoft.EntityFrameworkCore;
using MyBlog.API.Common;
using MyBlog.API.Models.Context;
using System.Linq.Expressions;

namespace MyBlog.API.Services
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        protected MyBlogContext db;
        protected DbSet<T> dbSet;
        public DbSet<T> DbSet { get; set; }
        public BaseService(MyBlogContext myBlogContext)
        {
            db = myBlogContext;
            dbSet = db.Set<T>();
        }

        public async Task<int> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return await db.SaveChangesAsync();

        }

        public async Task<int> RemoveAsync(int id)
        {
            var entity = await FindAsync(id);
            return await RemoveAsync(entity);
        }

        public async Task<int> RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            return await db.SaveChangesAsync();

        }

        public async Task<int> RemoveRangeAsync(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<T> entities)
        {
            dbSet.UpdateRange(entities);
            return await db.SaveChangesAsync();

        }

        public async ValueTask<T> FindAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<List<T>> Query()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<List<T>> Query(Expression<Func<T, bool>> func)
        {
            return await dbSet.Where(func).ToListAsync();
        }

        public async Task<List<T>> Query(int pageIndex, int size, RefAsync<int> total)
        {
            var qresult = dbSet.Skip((pageIndex - 1) * size).Take(size);
            total.Value = dbSet.Count();
            return await qresult.ToListAsync();

        }

        public async Task<List<T>> Query(Expression<Func<T, bool>> func, int pageIndex, int size, RefAsync<int> total)
        {
            var qresult = dbSet.Where(func).Skip((pageIndex - 1) * size).Take(size);
            total.Value = dbSet.Count();
            return await qresult.ToListAsync();
        }
    }

}

