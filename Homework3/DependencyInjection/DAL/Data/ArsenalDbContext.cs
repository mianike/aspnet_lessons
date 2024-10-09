using ArsenalFans.Models;
using Microsoft.EntityFrameworkCore;

namespace ArsenalFans.DAL.Data
{
    public class ArsenalDbContext : DbContext
    {
        public ArsenalDbContext(DbContextOptions<ArsenalDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
    }
}