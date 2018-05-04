using FreshVeg.Data.Context;
using FreshVeg.Data.Interfaces;
using FreshVeg.Models;

namespace FreshVeg.Data
{
    public class OrderRepository: GenericRepository<OrderContext, Order>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {
        }
    }
}
