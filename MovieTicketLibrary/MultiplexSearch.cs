using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTicketLibrary
{
    public class MultiplexSearch
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SelectMovie
    {
        public string Name { get; set; }
    }

    public class MovieDetails
    {
        public int MultiplexId { get; set; }
        public DateTime MovieDate { get; set; }
    }
    public class DisplayMovies
    {
        public string MovieName { get; set; }
        public int ShowId { get; set; }
        public int MovieId { get; set; }
        public int MutiplexId { get; set; }
        public string MultiplexName { get; set; }
        public  decimal Price { get; set; }
        public TimeSpan Showtime { get; set; }
        public string MovieImage { get; set; }
       
    }
    public class Bookdetails
    {
        public int ShowId { get; set; }
        public int BookedSeat { get; set; }
        public int BookingId { get; set; }
        public string seatno { get; set; }
        public int ticketno { get; set; }

    }
    
}
