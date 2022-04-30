using Library.BusinessLogic;
using Library.DataAccess;
using Library.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoBetter.BusinessLogic.impl {
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity {
        protected readonly IRepository<TEntity> repository;

        public BaseService(IRepository<TEntity> repository) {
            this.repository = repository;
        }
        public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes) {
            return await repository.GetAsync(filter, includes);
        }

        public virtual async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes) {
            return await repository.GetFirstAsync(filter, includes);
        }

        public virtual Task<TEntity> AddAsync(TEntity entity) {
            return repository.AddAsync(entity);
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entity) {
            return await repository.UpdateAsync(entity);
        }

        public virtual async Task<bool> ExistsAsync(int id) {
            return await repository.ExistsAsync(id);
        }

        public virtual async Task RemoveAsync(TEntity entity) {
            await repository.RemoveAsync(entity);
        }

    }
}
