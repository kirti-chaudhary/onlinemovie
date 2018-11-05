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
    [Route("SearchService")]
    [ApiController]
    public class SearchServiceController : ControllerBase
    {
        SearchService service;
        Movie_Ticket_BookingContext context;
        public SearchServiceController(Movie_Ticket_BookingContext context)
        {
            this.context = context;
            service = new SearchService(this.context);
        }
        [ServiceErrorFilter]
        [Route("GetCities")]
        [HttpGet]
        public List<string> GetCities()
        {
            var result = service.GetCities();
            return result;
        }
        [ServiceErrorFilter]
        [Route("GetMultiplex")]
        [HttpGet]
        public List<MultiplexSearch> GetMultiplex([FromQuery]string id)
        {
            var result = service.GetMultiplex(id);
            return result;
        }
        [ServiceErrorFilter]
        [Route("GetMovies")]
        [HttpPost]
        public List<DisplayMovies> GetMovies( MovieDetails details)
        {
            var result = service.GetMovies(details);
            return result;
        }
        [Route("SelectedShow")]
        [HttpGet]
        public BookSeat1 SelectedShow([FromQuery]string id)// 
        {
            int showid = Convert.ToInt32(id);
            var result = service.SelectedShow(id);
            //var result = service.SelectedShow(id);
            //return result;
            
            return result;

        }
    }
}
