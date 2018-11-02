using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate Next;
        public ExceptionHandlingMiddleware(RequestDelegate Next)
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
                context.Response.ContentType = "application/json";
               
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
   
}
