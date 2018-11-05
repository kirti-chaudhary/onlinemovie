using MovieTicketLibrary;
using OnlineMovieService.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieService.Models
{
    public class SearchService
    {


        Movie_Ticket_BookingContext context;
        public SearchService(Movie_Ticket_BookingContext context)
        {
            this.context = context;
        }
        public List<string> GetCities()
        {
            var result = (from m in context.Multiplex
                          select m.MultiplexCity).Distinct().ToList();
            return result;
        }


        public List<MultiplexSearch> GetMultiplex(string id)
        {
            var result = (from m in context.Multiplex
                          where m.MultiplexCity == id
                          select new MultiplexSearch()
                          {
                              Id = m.MultiplexId,
                              Name = m.MultiplexName
                          }).ToList();
            return result;


        }

        public List<DisplayMovies> GetMovies(MovieDetails details)
        {
            var result = (from s in context.Shows
                          join m in context.Movie on s.MovieId equals m.MovieId
                          join mp in context.Multiplex on s.MultiplexId equals mp.MultiplexId
                          where s.MultiplexId==details.MultiplexId && s.ShowDate==details.MovieDate
                          select new DisplayMovies()
                          {
                              MovieId = m.MovieId,
                              MovieName = m.MovieName,
                              MultiplexName = mp.MultiplexName,
                              ShowId=s.ShowId,
                              MutiplexId=mp.MultiplexId,
                              Price=s.Price,
                              Showtime=s.ShowTime,
                                MovieImage=m.MovieImage
                          }).ToList();

            return result;
        }
        public BookSeat1 SelectedShow(string id)
        {

            int showid = Convert.ToInt32(id);
            var result = (from s in context.Shows
                          join b in context.Bookingdetails on s.ShowId equals b.Showid
                          join bd in context.Bookedseat on b.Bookingid equals bd.Bookingid
                          where s.ShowId == showid

                          select bd.Seatno).ToList();
            var totalseats = (from c in context.Shows join m in context.MultiplexHall on c.HallId equals m.HallId select m.TotalSeats).First().Value;

            BookSeat1 book = new BookSeat1();
            book.Seatno = result;
            book.TotalSeats = totalseats;
            return book;

        }



    }

    }

