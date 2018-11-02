using System;

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
        public string Seatno { get; set; }
        public string TotalSeats { get; set; }
      

    }

}
