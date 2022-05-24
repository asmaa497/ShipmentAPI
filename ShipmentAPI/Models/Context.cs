using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShipmentAPI.Models
{
    public class Context:IdentityDbContext<ApplicationUser>
    {
        public Context()
        {

        }
        public Context(DbContextOptions options):base(options)
        {

        }

        public DbSet<Shipment> shipments { set; get; }
        public DbSet<Commodity> commodities { set; get; }
    }
}
