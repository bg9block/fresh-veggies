using AutoMapper;
using FreshVeg.API.Models;
using FreshVeg.Models;

namespace FreshVeg.API.Mapping
{
    public class OrderProductProfile: Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProductModel, OrderProduct>();
        }
    }
}