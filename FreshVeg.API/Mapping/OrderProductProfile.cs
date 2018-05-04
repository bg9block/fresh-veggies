using AutoMapper;
using ShoppingCart.API.Models;
using ShoppingCart.Models;

namespace ShoppingCart.API.Mapping
{
    public class OrderProductProfile: Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProductModel, OrderProduct>();
        }
    }
}