using System;
using System.Collections.Generic;

namespace OnlineMovieService.Models.DB
{
    public partial class Movie
    {
        public Movie()
        {
            Shows = new HashSet<Shows>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDuration { get; set; }
        public string Description { get; set; }
        public string MovieImage { get; set; }

        public ICollection<Shows> Shows { get; set; }
    }
}
