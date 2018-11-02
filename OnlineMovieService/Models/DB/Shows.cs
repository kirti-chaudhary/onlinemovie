using System;
using System.Collections.Generic;

namespace OnlineMovieService.Models.DB
{
    public partial class Shows
    {
        public int ShowId { get; set; }
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public int MultiplexId { get; set; }
        public decimal Price { get; set; }
        public DateTime ShowDate { get; set; }
        public TimeSpan ShowTime { get; set; }
        public int ShowTotalSeat { get; set; }
        public int? BookedSeat { get; set; }

        public Movie Movie { get; set; }
        public Multiplex Multiplex { get; set; }
    }
}
