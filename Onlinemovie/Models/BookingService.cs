
using Microsoft.AspNetCore.Http;
using MovieTicketLibrary;
using Newtonsoft.Json;
using OnlineMovieService.Models;
using OnlineMovieService.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Onlinemovie.Models
{
    public class BookingService
    {
        HttpClient client;
        public HttpContext Context;
        public BookingService() {

            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54515/");
        }
        public ShowInfo MakeBooking(string Paymentmode)
        {
            ShowInfo ticketInfo=null;
            int ShowId = Context.Session.GetInt32("ShowId").Value;
            int CustomerId = Context.Session.GetInt32("CustomerId").Value;
            string seats = Context.Session.GetString("seats");
             string[] Seats = JsonConvert.DeserializeObject <string[]>(seats);

            BookingInformation obj = new BookingInformation();
            obj.CustomerId = CustomerId;
            obj.Seatno = Seats;
            obj.ShowId = ShowId;
            obj.Paymentmode = Paymentmode;


            string json = JsonConvert.SerializeObject(obj);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

      HttpResponseMessage response = client.PostAsync("Booking/BookTickets", content).Result;
            if (response.IsSuccessStatusCode==true)
            {

                string ticketJson = response.Content.ReadAsStringAsync().Result;
                ticketInfo = JsonConvert.DeserializeObject<ShowInfo>(ticketJson);
            }
            return ticketInfo;
            
        }




    }
}
