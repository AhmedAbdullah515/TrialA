using Microsoft.EntityFrameworkCore;
using TrialA.App_Context;

namespace TrialA.Repo
{
    public class GenariceRepo<T>:IGenaricRepo<T> where T : class
    {
        protected AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenariceRepo(AppDbContext context)
        {
            _context = context;
            _dbSet =_context.Set<T>();
        }

        public async Task Add(T item)
        {
            await _dbSet.AddAsync(item);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Delet(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
    }
}
