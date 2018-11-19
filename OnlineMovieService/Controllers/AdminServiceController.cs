o
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicketLibrary;
using OnlineMovieService.Models;
using OnlineMovieService.Models.DB;
using WebApplication2.Models;

namespace OnlineMovieService.Controllers
{
    [ServiceErrorFilter]
    [Route("AdminService")]
    [ApiController]
    public class AdminServiceController : ControllerBase
    {
        AdminService service;
        Movie_Ticket_BookingContext context;
        public AdminServiceController(Movie_Ticket_BookingContext context)
        {
            this.context = context;
            service = new AdminService(this.context);
        }
        [ServiceErrorFilter]
        [Route("Validate")]
        [HttpPost]
        public IActionResult Authenticate(Credentials credentials)
        {
           
            {
                int result = service.Authenticate(credentials);
                if (result == 0)
                    return NotFound();
                else
                    return Ok(result);
            }
            
        }
        [ServiceErrorFilter] 
        [Route("AddNew")]
        [HttpPost]
        public IActionResult Reg(Register register)
        {
            int result = service.AddNew(register);

            return Ok(result);

        }
    }
}