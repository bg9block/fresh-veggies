using System;
using System.Linq;
using System.Linq.Expressions;
using ShoppingCart.Data;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Models;
using ShoppingCart.Services.Interfaces;

namespace ShoppingCart.Services
{
    public abstract class ServiceBase<TEntity> : IService<TEntity> 
        where TEntity : BaseEntity 
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        
        protected ServiceBase(IGenericRepository<TEntity> genericRepository) 
        { 
            _genericRepository = genericRepository;
        } 
        
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> whereCondition) 
        { 
            return _genericRepository.GetAll(whereCondition); 
        } 
        
        public int Count(Expression<Func<TEntity, bool>> whereCondition) 
        { 
            return _genericRepository.Count(whereCondition); 
        } 
    }
}