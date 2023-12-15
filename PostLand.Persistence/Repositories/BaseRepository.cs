using Microsoft.EntityFrameworkCore;
using PostLand.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly PostDbContext _postDbContext;

        public BaseRepository(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }
        public  async Task<T> AddAsync(T entity)
        {
             await _postDbContext.Set<T>().AddAsync(entity);
            await _postDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
             _postDbContext.Set<T>().Remove(entity);
            await _postDbContext.SaveChangesAsync();    
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await _postDbContext.Set<T>().FindAsync(Id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _postDbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
               _postDbContext.Entry(entity).State = EntityState.Modified;
            await _postDbContext.SaveChangesAsync();    
        }
    }
}
