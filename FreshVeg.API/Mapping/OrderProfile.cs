using AutoMapper;
using ShoppingCart.API.Models;
using ShoppingCart.Models;

namespace ShoppingCart.API.Mapping
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderModel, Order>();
        }
    }
}