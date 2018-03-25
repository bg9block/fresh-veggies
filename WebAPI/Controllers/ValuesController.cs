using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        // GET api/cart/total
        [HttpGet("total")]
        public string GetTotalFor(List<Guid> productIds, List<Guid> voucherIds)
        {
            return "value";
        }
    }
}