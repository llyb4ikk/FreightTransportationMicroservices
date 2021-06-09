using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Cargo_Application.Interfaces;
using Cargo_Application.Mapper;
using Cargo_Application.Services;
using Cargo_Infrastructure;
using Cargo_Infrastructure.ConnectionFactory;
using Cargo_Infrastructure.Interfaces;
using Cargo_Infrastructure.Interfaces.IRepositories;
using Cargo_Infrastructure.Repositories;
using MediatR;

namespace Cargo_API
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
            services.AddTransient<IConnectionFactory, ConnectionFactory>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ICargoRepository, CargoRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<ICargoService, CargoService>();

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddAutoMapper(typeof(MainMapperProfile));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cargo_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cargo_API v1"));
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
