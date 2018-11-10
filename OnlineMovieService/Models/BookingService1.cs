using MovieTicketLibrary;
using OnlineMovieService.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieService.Models
{
    public class BookingService1
    {
        public Movie_Ticket_BookingContext context;
        
        public BookingService1()
        {
            context = new Movie_Ticket_BookingContext();
            

        }
        public void BookTickets(BookingInformation bookinginformation)
        {
            
            Bookingdetails obj = new Bookingdetails();
            var result= (from s in context.Shows select s.Price).FirstOrDefault();

            obj.Customerid = bookinginformation.CustomerId;
            obj.Showid = bookinginformation.ShowId;
            obj.Paymentmethod = bookinginformation.Paymentmode;
            obj.Paymentdate = DateTime.Now;



        }
    }
}
