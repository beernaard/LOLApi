using System.Linq.Expressions;

namespace LOLApi.Interface
{
    public interface IUoF<T> where T : class
    {
        Task<IEnumerable<T>> GetAllData();
        Task<T> GetDataById(int id);
        IQueryable<T> GetDataBasedOnFilter(Expression<Func<T, bool>> filter);
        Task AddData(T entity);
        Task AddRange(IEnumerable<T> entity);
        void RemoveData(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
