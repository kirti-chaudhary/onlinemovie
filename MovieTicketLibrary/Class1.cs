using System;
using System.Collections.Generic;

namespace MovieTicketLibrary
{
    public class Credentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Register
    {
        public string Name { get; set; }
        public string EmailId { get; set;}

        public string Password { get; set; }
        public string Phoneno { get; set; }
    }
    public class BookSeat1
    {

        public List<string> Seatno { get; set; }
        public int TotalSeats { get; set; }
       
    }
    public class BookingInformation {
        public int CustomerId { get; set; }
        public int ShowId { get; set; }
        public string Paymentmode { get; set; }
        public string[] Seatno { get; set; }



    }

}
