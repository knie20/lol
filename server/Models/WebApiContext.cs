using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options) { }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Position> Positions { get; set; }
    }
}