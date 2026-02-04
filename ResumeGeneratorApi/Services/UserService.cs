#pragma warning restore 1591

using Microsoft.EntityFrameworkCore;
using ResumeGeneratorApi.Data;
using ResumeGeneratorApi.Data.Entities;

namespace ResumeGeneratorApi.Services
{
    public class UserService
    {
        private readonly ResumeDbContext _db;

        public UserService(ResumeDbContext db)
        {
            _db = db;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> CreateAsync(string email)
        {
            var user = new User
            {
                Email = email,
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return user;
        }
    }
}
