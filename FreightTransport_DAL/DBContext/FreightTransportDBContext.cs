using FreightTransport_DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.DBContext
{
    public class FreightTransportDBContext : IdentityDbContext<User>
    {

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDriver> CarDrivers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Transportation> Transportations { get; set; }

        public FreightTransportDBContext(DbContextOptions<FreightTransportDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cargo>()
                .HasOne(c => c.Client)
                .WithMany(cl => cl.Cargos)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<City>()
                .HasOne(c => c.Region)
                .WithMany(r => r.Cities)
                .HasForeignKey(c => c.RegionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Route>()
                .HasOne(r => r.DestinationCity)
                .WithMany(c => c.Routes)
                .HasForeignKey(r => r.DestinationCityId)
                .HasForeignKey(r => r.StartCityId) 
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Transportation>()
                .HasOne(t => t.Car)
                .WithMany(c => c.Transportations)
                .HasForeignKey(t => t.CarId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Transportation>()
                .HasOne(t => t.CarDriver)
                .WithMany(c => c.Transportations)
                .HasForeignKey(t => t.CarDriverId)
                .HasForeignKey(t => t.CarDriverSecondId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Transportation>()
                .HasOne(t => t.Cargo)
                .WithOne(c => c.Transportation)
                .HasForeignKey<Transportation>(t => t.CargoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Transportation>()
                .HasOne(t => t.Route)
                .WithMany(c => c.Transportations)
                .HasForeignKey(t => t.RouteId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" },
            //    new IdentityRole() { Name = "Client", NormalizedName = "CLIENT" }
            //);
        }
    }
}
