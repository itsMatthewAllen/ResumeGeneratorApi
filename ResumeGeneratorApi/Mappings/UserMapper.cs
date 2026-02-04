using ResumeGeneratorApi.DTOs;
using ResumeGeneratorApi.Data.Entities;

namespace ResumeGeneratorApi.Mappings
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email
            };
        }

        public static User ToEntity(string email)
        {
            return new User
            {
                Email = email
            };
        }
    }
}
