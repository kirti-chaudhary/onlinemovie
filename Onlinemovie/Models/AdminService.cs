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
    public class AdminService
    {
       public HttpContext context;
        HttpClient client;
        public AdminService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54515/");
        }
        [AppErrorFilter]
        public int Login(Credentials credentials)
        {
            string json = JsonConvert.SerializeObject(credentials);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/AdminService/Validate", content).Result;
            if (response.IsSuccessStatusCode == false)
            {
                return 0;
            }
            else
            {
                int id =Convert.ToInt32( response.Content.ReadAsStringAsync().Result);
                context.Session.SetInt32("CustomerId", id);
                return 1;
            }
        }
        [AppErrorFilter]
        public int AddNew(Register r)
        {
            string json = JsonConvert.SerializeObject(r);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/AdminService/AddNew", content).Result;

            if (response.IsSuccessStatusCode == true)
            {
                return 1;
            }
            return 0;

        }
        
    }
}
