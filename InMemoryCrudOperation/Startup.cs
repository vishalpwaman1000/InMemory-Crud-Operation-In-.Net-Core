using InMemoryCrudOperation.Context;
using InMemoryCrudOperation.DataAccessLayer;
using InMemoryCrudOperation.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCrudOperation
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InMemoryCrudOperation", Version = "v1" });
            });

            services.AddDbContext<UserDbContext>(service => service.UseInMemoryDatabase(Configuration["ConnectionStrings:InMemoryDatabase"]));
            services.AddScoped<ICrudOperationDL,CrudOperationDL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InMemoryCrudOperation v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var ScopeService = app.ApplicationServices.CreateScope();
            var ContextService = ScopeService.ServiceProvider.GetService<UserDbContext>();
            InsertSeedData(ContextService);
        }

        public static void InsertSeedData(UserDbContext dbContext)
        {
            try
            {

                UserDetails request = new UserDetails()
                {
                    UserName = "India",
                    Age = 5000
                };

                dbContext.UserDetails.Add(request);
                dbContext.SaveChanges();


            }catch(Exception ex)
            {
                throw new Exception($"Something Went Wrong : Exception Message : {ex.Message}");
            }
        }
    }
}
