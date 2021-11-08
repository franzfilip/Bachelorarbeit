using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.GraphQL.Contract {
    public interface IDataService<TEntity> {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> GetByIdAsync(int id);
        public Task<TEntity> AddAsync(TEntity author);
        public Task<TEntity> UpdateAsync(TEntity author);
        public Task RemoveAsync(int id);
        public Task<bool> EntityExistsAsync(int id);
    }
}
