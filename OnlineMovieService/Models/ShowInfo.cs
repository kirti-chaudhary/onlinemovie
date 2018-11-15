using OnlineMovieService.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieService.Models
{
    public class ShowInfo
    {
        public Bookedseat[] Seats {get;set;}
            public string MultiplexName { get; set; }
            public string HallName { get; set; }
        public string MovieName { get; set; }

    }
}
