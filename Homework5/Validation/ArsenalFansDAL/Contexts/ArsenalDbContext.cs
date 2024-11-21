using Microsoft.EntityFrameworkCore;

namespace ArsenalFansDAL.Contexts
{
    public partial class ArsenalDbContext : DbContext
    {
        public ArsenalDbContext(DbContextOptions<ArsenalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}