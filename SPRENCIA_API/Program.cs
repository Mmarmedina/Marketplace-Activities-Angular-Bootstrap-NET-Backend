
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace SPRENCIA_API
{
    public class Program
    {
        /* MMM 
        builder.Services.AddCors(options => 
        {
            options.AddPolicy("NuevaPolítica", app =>
            {
                app.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
                
            });

        });*/

        
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        // app.UseCors("NuevaPolítica");

    }


}


