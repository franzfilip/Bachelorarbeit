using Library.DataAccess;
using Library.Datamodel;
using Library.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoBetter.DataAccess.impl {
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity {
        protected readonly LibraryContext context;
        public Repository(IDbContextFactory<LibraryContext> contextFactory) {
            this.context = contextFactory.CreateDbContext();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes) {
            IQueryable<TEntity> query = context.Set<TEntity>();

            foreach (var include in includes) {
                query = query.Include(include);
            }

            if (filter != null) {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes) {
            IQueryable<TEntity> query = context.Set<TEntity>();

            foreach (var include in includes) {
                query = query.Include(include);
            }

            if (filter != null) {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity) {
            if (entity is null) {
                throw new ArgumentNullException(nameof(entity));
            }

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity) {
            if (entity is null) {
                throw new ArgumentNullException(nameof(entity));
            }

            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ExistsAsync(int id) {
            return await context.Set<TEntity>().AnyAsync(l => l.Id == id);
        }

        public virtual async Task RemoveAsync(TEntity entity) {
            if (entity is null) {
                throw new ArgumentNullException(nameof(entity));
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
