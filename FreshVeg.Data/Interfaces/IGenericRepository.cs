using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FreshVeg.Models;

namespace FreshVeg.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity: BaseEntity
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> whereCondition);
        int Count(Expression<Func<TEntity, bool>> whereCondition);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        void Save();
        Task SaveAsync();
    }
}