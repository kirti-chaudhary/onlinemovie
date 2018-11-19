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
    public class BookTestClass
    {
        BookingServiceController controller;
        Movie_Ticket_BookingContext context;

        public BookTestClass()
        {
            context = new Movie_Ticket_BookingContext();
            controller = new BookingServiceController();
        }
        [TestMethod]
        public void BookingTest()
        {
            //Arrange
            BookingInformation book = new BookingInformation()
            {
               CustomerId=8,
            ShowId = 1001,
            Paymentmode = "DC",

            };
            var result = controller.BookTickets(book);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}

