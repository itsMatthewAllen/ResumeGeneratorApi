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
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Id).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(u => u.CreatedAt).HasDefaultValueSql("now()");

                entity.Property(u => u.UpdatedAt).HasDefaultValueSql("now()");
            });
        }
    }
}
