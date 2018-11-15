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
                Id = 100,
                Name = "abcd"
            };
            //Act
            var result = controller.GetMultiplex("Noida");
            Assert.AreEqual(2, result.Count);
        }

        class Movie
        {

        }
        [TestMethod]
        public void SearchMovie()
        {

            //Act
            MovieDetails m = new MovieDetails();
            m.MultiplexId = 100;
            m.MovieDate = Convert.ToDateTime("2018-11-20");
             var result = controller.GetMovies(m);
             Assert.AreEqual(4,result.Count);
        }
        [TestMethod]
        public void Show()
        {
            BookSeat1 book = new BookSeat1()
            {

            };
            var result = controller.SelectedShow(1001);
            Assert.AreEqual(5,result.Seatno.Count);
           
        }
        

    }
}

