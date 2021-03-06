﻿using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class AppExceptionHandlingMiddleware
    {
        public RequestDelegate Next;
        public AppExceptionHandlingMiddleware(RequestDelegate Next)
        {
            this.Next = Next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch(Exception e)
            {
                context.Response.ContentType = "text/html";
                string Html = $"<div><a href='Search/Search'>Go to Search Page</a></div><div>{e.Message}</div>";
                await context.Response.WriteAsync(Html);
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
   
}
