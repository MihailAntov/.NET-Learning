using Packt.Shared;
using static System.Console;

namespace NorthwindWeb
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddNorthwindContext();
            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }
            app.UseRouting();

            app.Use(async(HttpContext context, Func<Task> next) => 
            {
                RouteEndpoint rep = context.GetEndpoint() as RouteEndpoint;
                if (rep is not null)
                {
                    WriteLine($"Endpoint name: {rep.DisplayName}");
                    WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
                }

                if (context.Request.Path == "/bonjour")
                {
                    //in the case of a match on URL path, this becomes a terminating
                    //delegate that returns so it does not call the next delegate
                    await context.Response.WriteAsync("Bonjour Monde!");
                    return;
                }
                
                //if (context.Request.Path.ToString().Contains("/order"))
                //{
                //    NorthwindWeb.Pages.OrderModel.QueryID = context.Request.QueryString.ToString().Substring(1);
                //    WriteLine("Are we getting here?");
                //}
                //we could modify the request before calling the next delegeate
                await next();
                //we could modify the request after calling the next delegate
            });

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapRazorPages();

                endpoints.MapGet("/hello", () => "Hello World!");
            });
        }
    }
}