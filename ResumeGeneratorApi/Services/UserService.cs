#pragma warning restore 1591

using Microsoft.EntityFrameworkCore;
using ResumeGeneratorApi.Data;
using ResumeGeneratorApi.Data.Entities;

namespace ResumeGeneratorApi.Services
{
    /// <summary>
    /// Provides user-related business logic and data access methods.
    /// </summary>
    public class UserService
    {
        private readonly ResumeDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class;
        /// </summary>
        /// <param name="db">The database context used to access user data.</param>
        public UserService(ResumeDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Retrieves a user by their unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation.  The task result contains the user if found; otherwise, null</returns>
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Creates a new user with the specified email address asynchronously.
        /// </summary>
        /// <param name="email">The email address of the new user.</param>
        /// <returns>A task that represents the asynchronous operation.  The task result contains the created user entity.</returns>
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
