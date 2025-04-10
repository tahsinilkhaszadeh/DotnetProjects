using Microsoft.EntityFrameworkCore;


namespace DemoWebApi.Data
{
    public class DemoDbContext: DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }
        public DbSet<DemoWebApi.Domain.Entities.Product> Products { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoDbContext).Assembly);
        }
    }
    
}
