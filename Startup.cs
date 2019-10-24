using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

//Register Context Class as a service
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //With our Context class created we need to add it as a service so that we can use dependency injection with our controllers.  
            string mySqlConnection = "server=localhost;userid=root;password=root;port=3306;database=crudelicious;SslMode=None";

            //inject the context we made
            services.AddDbContext<CruddyContext>(options => options.UseMySql(mySqlConnection));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
