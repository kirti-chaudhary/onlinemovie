 using Microsoft.AspNetCore.Http;
using MovieTicketLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        //public List<Bookdetails> SelectedShow(MovieDetails details)
        //{
        //    string req = "SearchService/SelectedShow";

        //    string json = JsonConvert.SerializeObject(details);

        //    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = client.PostAsync(req, content).Result;
        //    //HttpResponseMessage response = client.GetAsync(req, content).Result;
        //    json = response.Content.ReadAsStringAsync().Result;
        //    List<Bookdetails> shows = JsonConvert.DeserializeObject<List<Bookdetails>>(json);
        //    return shows;
        //}
       
        
            List<Bookdetails> serializedObjects;
            string json = "";
            byte[] ary;

            // json = context.Session.GetString("CatSubCat");
            // SubCategory subcategory = JsonConvert.DeserializeObject<SubCategory>(json);
            //bool isavailable = context.Session.TryGetValue("Showid", out ary);
            //if (isavailable == false)
            //{
            //    serializedObjects = new List<Bookdetails>();
            //    serializedObjects.Add(model);
            //    serializedObjects = serializedObjects.Distinct().ToList();
            //    json = JsonConvert.SerializeObject(serializedObjects);
            //    context.Session.SetString("Cart", json);
            //}
            //else
            //{
            //    json = context.Session.GetString("Cart");
            //    serializedObjects = JsonConvert.DeserializeObject<List<Bookdetails>>(json);
            //    serializedObjects.Add(model);
            //    serializedObjects = serializedObjects.Distinct().ToList();
            //    json = JsonConvert.SerializeObject(serializedObjects);
            //    context.Session.SetString("Cart", json);
            //}

        

    
}
}
