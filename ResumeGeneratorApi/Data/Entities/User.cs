using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeGeneratorApi.Data.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; } = null!;

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
