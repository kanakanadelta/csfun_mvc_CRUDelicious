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
using Microsoft.Extensions.Configuration;

namespace CRUDelicious
{
    public class Startup
    {
        // This public getter will be how you access the data from appsettings.json
        // To access the connection string itself, you would use the following:
        // Configuration["DBInfo:ConnectionString"]
        public IConfiguration Configuration {get;}

        // Here we will "inject" the default IConfiguration service, which will bind to appsettings.json by default
        // and then assign it to the Configuration property.  This happens at the startup of our application.
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //////////////////////////////
            //   OLD DB CONNECTION    //
            //With our Context class created we need to add it as a service so that we can use dependency injection with our controllers.  
            // string mySqlConnection = "server=localhost;userid=<<<user>>>;password=<<<pw>>>;port=<<<portnum>>>;database=<<<<dbname>>>>;SslMode=None";

            //inject the context we made
            // services.AddDbContext<CruddyContext>(options => options.UseMySql(mySqlConnection));

            // END - OLD DB CONNECTION//
            ///////////////////////////

            // Now we may use the connection string itself, bound to Configuration, to pass the required connection
            // credentials to MySQL
            services.AddDbContext<CruddyContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"]));

            //other services
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
