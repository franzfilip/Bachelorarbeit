using Library.Datamodel;
using System.Linq.Expressions;

namespace Library.DataAccess {
    public interface IRepository<TEntity> where TEntity : BaseEntity {
        public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        public Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task<bool> ExistsAsync(int id);
        public Task RemoveAsync(TEntity entity);
    }
}