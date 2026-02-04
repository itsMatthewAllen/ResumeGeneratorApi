#pragma warning restore 1591

namespace ResumeGeneratorApi.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
    }
}
