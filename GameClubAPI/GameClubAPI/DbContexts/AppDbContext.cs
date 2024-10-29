using GameClubAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameClubAPI.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Clubs> Clubs { get; set; }
        public DbSet<Events> Events { get; set; }
    }
}
