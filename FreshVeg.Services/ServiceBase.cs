using System;
using System.Linq;
using System.Linq.Expressions;
using FreshVeg.Data.Interfaces;
using FreshVeg.Models;
using FreshVeg.Services.Interfaces;

namespace FreshVeg.Services
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