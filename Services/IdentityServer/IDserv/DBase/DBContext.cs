using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IDserv.DBase
{
    public class DBContext : IdentityDbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole() {Name = "Admin", NormalizedName = "Admin".ToUpper()},
            //    new IdentityRole() {Name = "User", NormalizedName = "User".ToUpper()}
            //);
        }
    }
}