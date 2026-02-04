using Microsoft.EntityFrameworkCore;
using ResumeGeneratorApi.Data.Entities;

namespace ResumeGeneratorApi.Data
{
    public class ResumeDbContext : DbContext
    {
        public ResumeDbContext(DbContextOptions<ResumeDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResumeDbContext).Assembly);
        }
    }
}
