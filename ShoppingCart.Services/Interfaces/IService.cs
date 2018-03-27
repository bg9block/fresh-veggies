using System;
using System.Linq;
using System.Linq.Expressions;
using ShoppingCart.Models;

namespace ShoppingCart.Services.Interfaces
{
    public interface IService<T>
    where T: BaseEntity
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> whereCondition);
        int Count(Expression<Func<T, bool>> whereCondition);
    }
}