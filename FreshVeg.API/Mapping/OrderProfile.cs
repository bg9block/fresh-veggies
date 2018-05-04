using AutoMapper;
using FreshVeg.API.Models;
using FreshVeg.Models;

namespace FreshVeg.API.Mapping
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderModel, Order>();
        }
    }
}