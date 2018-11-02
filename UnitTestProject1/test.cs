using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineMovieService.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineMovieService.Models.DB;
using MovieTicketLibrary;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMovieUnitTests
{
    [TestClass]
  public  class OnlineMovieTestClass
    {
        AdminServiceController controller;
        Movie_Ticket_BookingContext context;
       
        public OnlineMovieTestClass()
        {
            context = new Movie_Ticket_BookingContext();
            controller = new AdminServiceController(context);
        }
        [TestMethod]
        public void AuthenticationTestForValidCredentials()
        {
            Credentials credentials = new Credentials()
            {
                 Email= "kirti@gmail.com",
                  Password="kirti"
            };
           var result= (OkObjectResult)controller.Authenticate(credentials);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
       
        [TestMethod]
        public void AuthenticationTestForInValidCredentials()
        {
            Credentials credentials = new Credentials()
            {
                Email = "",
                Password = ""
            };
            var result = (NotFoundResult)controller.Authenticate(credentials);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void CreateNewUserTest()
        {
            //Arrange
            Register register = new Register()
            {
                Name = "kirti",
                EmailId = "kirti@gmail.com",
                Password = "kirti",
              Phoneno = "123490"
            };
            //Act
            var result = controller.Reg(register);

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        




    }
     
    
}
