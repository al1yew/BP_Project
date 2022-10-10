using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BP.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        Task<List<TEntity>> GetAllAsync(params string[] includes);
        Task<List<TEntity>> GetAllByExAsync(Expression<Func<TEntity, bool>> ex, params string[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> ex, params string[] includes);
        void Remove(TEntity entity);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> ex);
        void UpdateAsync(TEntity entity);
    }
}
