using FSCTMM_HFT_2023241.Logic.classes;
using FSCTMM_HFT_2023241.Logic.Inetfaces;
using FSCTMM_HFT_2023241.Models;
using FSCTMM_HFT_2023241.Repository;
using FSCTMM_HFT_2023241.Repository.ModelRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Endpoint
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddTransient<AirplaneDbContext>();

            services.AddTransient<Irepository<Airplane>, AirplaneRepository>();
            services.AddTransient<Irepository<Airports>, AirportRepository>();
            services.AddTransient<Irepository<Crew>, CrewRepository>();
                   
     

          
            services.AddTransient<IAirplaneLogic, AirplaneLogic>();
            services.AddTransient<IAirportLogic, AirportLogic>();
            services.AddTransient<ICrewLogic, CrewLogic>();

            //services.AddControllersWithViews();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FSCTMM_HFT_2023241.Endpoint", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FSCTMM_HFT_2023241.Endpoint v1"));
            }
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
