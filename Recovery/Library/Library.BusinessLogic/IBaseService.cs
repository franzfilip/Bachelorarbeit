using Library.Datamodel;
using System.Linq.Expressions;

namespace Library.BusinessLogic {
    public interface IBaseService<TEntity> where TEntity: BaseEntity {
        public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        public Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task<bool> ExistsAsync(int id);
        public Task RemoveAsync(TEntity entity);
    }
}