using System.IO;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;
using NorthwindWeb;



Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder=>
{
    webBuilder.UseStartup<Startup>();
    }).Build().Run();
Console.WriteLine("This executes after the web server has stopped.");

