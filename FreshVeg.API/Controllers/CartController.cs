using System.Linq;
using AutoMapper;
using FreshVeg.API.Models;
using FreshVeg.Models;
using FreshVeg.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreshVeg.API.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly IMapper _mapper;

        private IOrderService OrderService { get; set; }
        private IVoucherService VoucherService { get; set; }

        public CartController(IOrderService orderService, IVoucherService voucherService, IMapper mapper)
        {
            _mapper = mapper;
            OrderService = orderService;
            VoucherService = voucherService;
        }
        
        // POST api/cart/totalPrice
        [HttpPost("totalPrice")]
        public ActionResult TotalPrice([FromBody] OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            orderModel.Vouchers = VoucherService.GetAll(v => orderModel.VoucherIds.Contains(v.Id)).ToList();
            var order = _mapper.Map<Order>(orderModel);
            var price = OrderService.GetTotalPriceFor(order);
            
            return new JsonResult(price);
        }
        
        // GET api/cart/sayHello
        [HttpGet("sayHello")]
        public string SayHello([FromQuery] string name)
        {
            return $"Hello {name}!";
        }
    }
}