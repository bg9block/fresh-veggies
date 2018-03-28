using System;
using System.Linq;
using System.Linq.Expressions;
using ShoppingCart.Models;

namespace ShoppingCart.Services.Interfaces
{
    public interface IOrderService: IService<Order>
    {
        double GetTotalPriceFor(Order order);
    }
}