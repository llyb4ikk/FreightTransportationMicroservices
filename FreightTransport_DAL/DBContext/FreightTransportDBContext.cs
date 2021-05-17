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
    public class FreightTransportDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDriver> CarDrivers { get; set; }
        public DbSet<DriverSalary> DiverSalaries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Transportation> Transportations { get; set; }

        public FreightTransportDBContext(DbContextOptions<FreightTransportDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cargo>()
                .HasOne(c => c.Owner)
                .WithMany(cl => cl.Cargos)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Cargo>()
                .HasOne(c => c.Transportation)
                .WithMany(t => t.Cargos)
                .HasForeignKey(c => c.TransportationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Transportation>()
                .HasOne(r => r.DestinationCity)
                .WithMany(c => c.DestinationRoutes)
                .HasForeignKey(r => r.DestinationCityId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Transportation>()
                .HasOne(r => r.StartCity)
                .WithMany(c => c.StartRoutes)
                .HasForeignKey(r => r.StartCityId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Transportation>()
                .HasOne(t => t.Car)
                .WithMany(c => c.Transportations)
                .HasForeignKey(t => t.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DriverSalary>()
                .HasOne(ds => ds.CarDriver)
                .WithMany(cd => cd.Salaries)
                .HasForeignKey(ds => ds.CarDriverId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<DriverSalary>()
                .HasOne(ds => ds.Transportation)
                .WithMany(cd => cd.DriverSalaries)
                .HasForeignKey(ds => ds.TransportationId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
