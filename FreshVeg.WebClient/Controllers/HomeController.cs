using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FreshVeg.Web.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public IActionResult Index()
        {
            ViewData["Configuration"] = _configuration;
            return View();
        }
    }
}
