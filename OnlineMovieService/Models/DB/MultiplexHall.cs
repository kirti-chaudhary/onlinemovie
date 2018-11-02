using System;
using System.Collections.Generic;

namespace OnlineMovieService.Models.DB
{
    public partial class MultiplexHall
    {
        public int HallId { get; set; }
        public string HallName { get; set; }
        public int? MultiplexId { get; set; }
        public int? TotalSeats { get; set; }
    }
}
