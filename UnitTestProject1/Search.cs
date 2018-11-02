using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieTicketLibrary;
using OnlineMovieService.Controllers;
using OnlineMovieService.Models.DB;

namespace OnlineMovieUnitTests
{
    [TestClass]
    public class SearchTestClass
    {
        SearchServiceController controller;
        Movie_Ticket_BookingContext context;

        public SearchTestClass()
        {
            context = new Movie_Ticket_BookingContext();
            controller = new SearchServiceController(context);
        }
        class Search
        {
        }
        [TestMethod]
        public void SearchMultiplexTest()
        {
            //Arrange
            MultiplexSearch search = new MultiplexSearch()
            {
                Id=100,
                Name="abcd"
            };
            //Act
            var result = controller.GetMultiplex("Mumbai");
            Assert.IsNotNull(result);
        }
    }
}
