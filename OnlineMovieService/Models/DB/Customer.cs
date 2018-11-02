using System;
using System.Collections.Generic;

namespace OnlineMovieService.Models.DB
{
    public partial class Customer
    {
        public Customer()
        {
            Bookingdetails = new HashSet<Bookingdetails>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Phoneno { get; set; }

        public ICollection<Bookingdetails> Bookingdetails { get; set; }
    }
}
