using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Onlinemovie.Models;

namespace Onlinemovie.Controllers
{
    public class BookingController : Controller
    {
      
        public IActionResult BookShow(string mode)
        {

            return View();
        }
        [HttpPost]
        [HttpGet]
        public IActionResult Payment(string mode)
        {
            BookingService obj;

            obj = new BookingService();
            obj.Context = HttpContext;
            var result = obj.MakeBooking(mode);
            ViewData["ticketinfo"] = result;
            return View("Invoice");
        }
      
    }
}