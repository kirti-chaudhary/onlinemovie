using MovieTicketLibrary;
using OnlineMovieService.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace OnlineMovieService.Models
{
    public class AdminService
    {
        Movie_Ticket_BookingContext context;
        public AdminService(Movie_Ticket_BookingContext context)
        {
            this.context = context;
        }
        [ServiceErrorFilter]
        public int Authenticate(Credentials credentials)
        {
            int result = (from c in context.Customer
                          where c.EmailId == credentials.Email && c.Password == credentials.Password
                          select c.CustomerId).FirstOrDefault();
            return result;
        }
        [ServiceErrorFilter]
        public int AddNew(Register register)
        {
            Customer customer = new Customer() {
                 EmailId=register.EmailId,
                 Name=register.Name,
                 Password=register.Password,
                 Phoneno=register.Phoneno
                
            };
           context.Add(customer);
           int entry= context.SaveChanges();
            return entry;
        }
    }
}

