using FreshVeg.Models;

namespace FreshVeg.Services.Interfaces
{
    public interface IOrderService: IService<Order>
    {
        decimal GetTotalPriceFor(Order order);
    }
}