using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AncestryPrototype.Data;
using AncestryPrototype.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace WebApplication4
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AncestryContext>(opt => opt.UseInMemoryDatabase());
            services.AddDbContext<AncestryContext>(options => options.UseInMemoryDatabase("TestDB"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

            //var context = app.ApplicationServices.GetService<AncestryContext>();

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AncestryContext>();
                // Seed the database.
                AddTestData(context);
            }
           
        }

        private static void AddTestData(AncestryContext context)
        {
            var jsonString = File.ReadAllText(@".\sampleData\data_small.json");
            var sampleData = JsonConvert.DeserializeObject<SanmpleData>(jsonString);

            foreach(var p in sampleData.People)
            {
                var person = new Person()
                {
                    PersonId = p.PersonId,
                    Name = p.Name,
                    Gender = p.Gender,
                    Level = p.Level,
                    Birthplace = p.Birthplace,
                    FatherId = p.FatherId,
                    PlaceId = p.PlaceId,
                    MotherId = p.MotherId
                };
                context.People.Add(person);
            }

            foreach (var p in sampleData.Places)
            {
                var place = new Place()
                {
                   PlaceId = p.PlaceId,
                   Name = p.Name
                };
                context.Places.Add(place);
            }
            context.SaveChanges();

        }

    }
}
