using FreightTransport_DAL.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreightTransport.Mapping;
using FreightTransport_BLL.Interfaces.IServices;
using FreightTransport_BLL.Services;
using FreightTransport_DAL;
using FreightTransport_DAL.Interfaces;
using FreightTransport_DAL.Interfaces.IRepositories;
using FreightTransport_DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreightTransport
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
            services.AddTransient<FreightTransportDBContext>();

            services.AddTransient<ICarDriverRepository, CarDriverRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ITransportationRepository, TransportationRepository>();
            services.AddTransient<IDriverSalaryRepository, DriverSalaryRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICarDriverService, CarDriverService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ITransportationService, TransportationService>();
            services.AddTransient<IDriverSalaryService, DriverSalaryService>();

            services.AddAutoMapper(typeof(MainMappingProfile));

            services.AddControllers();

            services.AddDbContext<FreightTransportDBContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "freighttransportapi";
                    options.Authority = "https://localhost:44366";
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FreightTransport", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FreightTransport v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
