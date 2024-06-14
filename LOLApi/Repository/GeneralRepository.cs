using LOLApi.Data;
using LOLApi.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LOLApi.Repository
{
    public class GeneralRepository<T> : IUoF<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbEntity;
        public GeneralRepository(ApplicationDbContext context)
        {
            _context = context;
            this.dbEntity = _context.Set<T>();  
        }

        public async Task AddData(T entity)
        {
            await dbEntity.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entity)
        {
            await dbEntity.AddRangeAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllData()
        {
            IQueryable<T> query = dbEntity;
            //var query = dbEntity;
            return await query.ToListAsync();
        }

        public IQueryable<T> GetDataBasedOnFilter(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbEntity;
            query = query.Where(filter);
            return query;
        }

        public async Task<T> GetDataById(int id)
        {
            return await dbEntity.FindAsync(id);
        }

        public void RemoveData(T entity)
        {
            dbEntity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbEntity.RemoveRange(entity);
        }

       
    }
}
