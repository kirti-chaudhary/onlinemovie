using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieTicketLibrary;
using OnlineMovieService.Models;

namespace OnlineMovieService.Controllers
{
    [Route("Booking")]
    [ApiController]
    public class BookingServiceController : ControllerBase
    {
        [Route("BookTickets")]
        [HttpPost]
        public IActionResult BookTickets(BookingInformation bookingInformation)
        {
            BookingService1 obj = new BookingService1();
            obj.BookTickets(bookingInformation);

            return Ok();
        }
    }
}