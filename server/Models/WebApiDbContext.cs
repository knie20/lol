using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) { }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Position> Positions { get; set; }
    }
}