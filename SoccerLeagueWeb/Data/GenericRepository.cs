using Microsoft.EntityFrameworkCore;
using SoccerLeagueLibrary.Data.Entities;

namespace SoccerLeagueWeb.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
            await SaveAllAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveAllAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveAllAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Set<T>().AnyAsync(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                 .AsNoTracking()
                 .FirstOrDefaultAsync(e => e.Id == id);
        }

        private async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
