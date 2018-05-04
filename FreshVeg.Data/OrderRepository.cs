
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Models;

namespace ShoppingCart.Data
{
    public class OrderRepository: GenericRepository<OrderContext, Order>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {
        }
    }
}
