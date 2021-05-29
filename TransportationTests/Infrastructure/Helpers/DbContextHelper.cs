using FreightTransport_DAL.DBContext;
using Microsoft.EntityFrameworkCore;

namespace TransportationTests.Infrastructure.Helpers
{
    public class DbContextHelper
    {
        public FreightTransportDBContext Context { get; set; }
        public DbContextHelper()
        {
            var builder = new DbContextOptionsBuilder<FreightTransportDBContext>();
            builder.UseInMemoryDatabase("Transportation_Testing_InMemoryDatabase");

            var options = builder.Options;
            Context = new FreightTransportDBContext(options);

            Context.AddRange();

            Context.SaveChanges();
        }
    }
}