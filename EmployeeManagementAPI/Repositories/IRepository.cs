using EmployeeManagementModel;
using System.Linq.Expressions;

namespace EmployeeManagementAPI.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> Search(Expression<Func<T, bool>> filter);
        public Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] children);
        public Task<T> GetSingle(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] children);
        public Task<T> Add(T entity);
        public Task<T> UpdateEntity(T entity);
        public Task Delete(Expression<Func<T, bool>> filter);
        public Task Save();
    }
}
