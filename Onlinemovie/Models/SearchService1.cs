using Microsoft.AspNetCore.Http;
using MovieTicketLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebApplication2.Models;

namespace Onlinemovie.Models
{
    public class SearchService1
    {

        HttpClient client;
        public SearchService1()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54515/");
        }
        [AppErrorFilter]
        public List<string> City()
        {
            string req = "SearchService/GetCities";
            List<string> cities;
            HttpResponseMessage response = client.GetAsync(req).Result;
            
                string str=response.Content.ReadAsStringAsync().Result;
                cities=JsonConvert.DeserializeObject<List<string>>(str);
                return cities;
        }
        [AppErrorFilter]
        public List<DisplayMovies> GetMovies(MovieDetails details)
        {
            string req = "SearchService/GetMovies";
            
            string json = JsonConvert.SerializeObject(details);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(req, content).Result;
            //HttpResponseMessage response = client.GetAsync(req, content).Result;
            json =response.Content.ReadAsStringAsync().Result;
            List<DisplayMovies>  shows=JsonConvert.DeserializeObject<List<DisplayMovies>>(json);
            return shows;
        }
        public BookSeat1  SelectedShow(int id)
        {
            string req = "SearchService/SelectedShow/"+ id;



            HttpResponseMessage response = client.GetAsync(req).Result;
            //HttpResponseMessage response = client.GetAsync(req, content).Result;
            string json = response.Content.ReadAsStringAsync().Result;
            BookSeat1 seatno = JsonConvert.DeserializeObject<BookSeat1>(json);
            return seatno;
        }

        public void StoreSeatsInSession(string[] seats,HttpContext context)
        {
            string json = JsonConvert.SerializeObject(seats);
            context.Session.SetString("seats", json);
        }
        
        public void BookedTicketPayment(string[] mode)
        {
            string json = JsonConvert.SerializeObject(mode);
        }


    }
}
