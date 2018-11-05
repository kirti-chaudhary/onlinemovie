using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieTicketLibrary;
using Onlinemovie.Models;
using WebApplication2.Models;

namespace Onlinemovie.Controllers
{
    public class SearchController : Controller
    {
        SearchService1 service;
        public SearchController()
        {
            service = new SearchService1();
        }

        public IActionResult SearchView()
        {
            try
            {
                var result = service.City();
                SelectList citylist = new SelectList(result);
                ViewBag.cities = citylist;
                return View();
            }
            catch (Exception e)
            {
                ErrorViewModel m = new ErrorViewModel() { RequestId = e.Message };
                return View("Error", m);
            }

        }
        [AppErrorFilter]
             public IActionResult GetMovies(MovieDetails details)
        {

            var result =  service.GetMovies(details);
           return View(result);
        }
        [AppErrorFilter]
        public IActionResult SelectedShow(int showid)
        {
            // var result = service.SelectedShow(showid);
           
            return null;
        }

    }
}