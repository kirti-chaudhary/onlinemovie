using System;
using System.Collections.Generic;

namespace OnlineMovieService.Models.DB
{
    public partial class Bookingdetails
    {
        public Bookingdetails()
        {
            Bookedseat = new HashSet<Bookedseat>();
        }

        public int Bookingid { get; set; }
        public int Customerid { get; set; }
        public int? Showid { get; set; }
        public int? Totalprice { get; set; }
        public string Paymentmethod { get; set; }
        public DateTime? Paymentdate { get; set; }
        public TimeSpan? Paymenttime { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Bookedseat> Bookedseat { get; set; }
    }
}
