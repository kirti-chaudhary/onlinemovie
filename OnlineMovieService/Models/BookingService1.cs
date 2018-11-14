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
        public Bookedseat[] BookTickets(BookingInformation bookinginformation)
        {

            Bookingdetails obj = new Bookingdetails();

            Shows obj1 = new Shows();
            var showobj = (from s in context.Shows where s.ShowId == bookinginformation.ShowId select s).FirstOrDefault();
            

          

                obj.Customerid = bookinginformation.CustomerId;
                obj.Showid = bookinginformation.ShowId;
                obj.Paymentmethod = bookinginformation.Paymentmode;
                obj.Paymentdate = DateTime.Now;
                obj.Totalprice = bookinginformation.Seatno.Length * (int)showobj.Price;
                obj.Paymenttime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                context.Bookingdetails.Add(obj);
                context.SaveChanges();

                //--------------------------------------------------
                Bookedseat temp;
                foreach(string seat in bookinginformation.Seatno)
                {
                    temp = new Bookedseat() { Seatno =seat, Bookingid=obj.Bookingid };
                    context.Bookedseat.Add(temp);
                }
                showobj.BookedSeat += bookinginformation.Seatno.Length;
                context.SaveChanges();

            var ticketNosForInvoice = (from b in context.Bookedseat where b.Bookingid == obj.Bookingid select b).ToArray();
            return ticketNosForInvoice;
            }
        }
    }

