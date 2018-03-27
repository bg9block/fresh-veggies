using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.API.Models;
using ShoppingCart.Models;
using ShoppingCart.Services.Interfaces;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly IMapper _mapper;

        private IOrderService OrderService { get; set; }

        public CartController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            OrderService = orderService;
        }
        
        // GET api/cart/totalPrice
        [HttpGet("total")]
        public ActionResult GetTotalFor(OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }

            var order = _mapper.Map<Order>(orderModel);
            var price = OrderService.GetTotalPriceFor(order);
            
            return new JsonResult(price);
        }
        
        // GET api/cart/total
        [HttpGet("sayHello")]
        public string SayHello()
        {
            return "hello";
        }
    }
}