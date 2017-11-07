using _01._ASP.NET_Core_Introduction.Data;
using _01._ASP.NET_Core_Introduction.Infrastructure.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _01._ASP.NET_Core_Introduction
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CatsDbContext>(options =>
                                                 options
                                                .UseSqlServer(
                                                "Server=DESKTOP-52OK68M\\SQLEXPRESS;Database=CatsDB;Integrated Security=True;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDatabaseMigration()
               .UseStaticFiles()
               .UseHtmlContentType()
               .UseRequestHandlers()
               .UseNotFoundHandler();
        }
    }
}
