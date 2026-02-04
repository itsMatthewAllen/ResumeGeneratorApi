using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumeGeneratorApi.Data.Entities;

namespace ResumeGeneratorApi.Data.Configurations
{
    /// <summary>
    /// Entity Framework configuration for the User entity.
    /// Maps properties to database columns and applies query filters.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("users");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.Email).HasColumnName("email").IsRequired();
            entity.Property(e => e.CreatedAt).HasColumnName("created_at").ValueGeneratedOnAdd();
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").ValueGeneratedOnAddOrUpdate();
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

            entity.HasQueryFilter(e => e.DeletedAt == null);
        }
    }
}
