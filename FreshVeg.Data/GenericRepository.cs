using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FreshVeg.Data.Interfaces;
using FreshVeg.Models;
using Microsoft.EntityFrameworkCore;

namespace FreshVeg.Data
{   
    public abstract class GenericRepository<TContext, TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext, new() {

        private TContext _entities;
        public TContext Context {    

            get { return _entities; }
            set { _entities = value; }
        }

        protected GenericRepository(TContext context)
        {
            _entities = context;
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate) {

            return _entities.Set<TEntity>().Where(predicate);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Set<TEntity>().Count(predicate);
        }

        public virtual void Add(TEntity entity) {
            _entities.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity) {
            _entities.Set<TEntity>().Remove(entity);
        }

        public virtual void Edit(TEntity entity) {
            _entities.Entry(entity).State = EntityState.Modified;
        }


        public virtual void Save() {
            _entities.SaveChanges();
        }
        
        public virtual async Task SaveAsync() {
            await _entities.SaveChangesAsync();
        }
    }
}

