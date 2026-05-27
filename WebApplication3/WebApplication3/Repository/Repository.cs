using Microsoft.EntityFrameworkCore;
using WebApplication3.Context;

namespace WebApplication3.Repository
{
    public class Repository<T> : IRepository<T>
            where T : class
    {
        private readonly AppDbContext _context;

        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;

            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);

            await Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
