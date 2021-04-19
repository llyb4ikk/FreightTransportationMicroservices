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

            services.AddTransient<ICargoRepository, CargoRepository>();
            services.AddTransient<ICarDriverRepository, CarDriverRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IRouteRepository, RouteRepository>();
            services.AddTransient<ITransportationRepository, TransportationRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICarDriverService, CarDriverService>();
            services.AddTransient<ICarService, CarService>();

            services.AddAutoMapper(typeof(MainMappingProfile));

            services.AddControllers();

            services.AddDbContext<FreightTransportDBContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
