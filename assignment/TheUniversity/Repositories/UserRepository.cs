using Dapper;
using System.Data;
using TheUniversity.Models;

namespace TheUniversity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _conn;

        public UserRepository(IDbConnection conn)
        {
            _conn = conn ?? throw new ArgumentNullException(nameof(conn));
        }

        public Task<User?> Find(string email)
        {
            return _conn.QuerySingleOrDefaultAsync<User?>(@"
                SELECT Id, Email, PasswordHash, Roles, StudentId
                FROM [User] WHERE Email = @email",
                new { email = email }
            );
        }

        public Task Create(User user)
        {
            return _conn.ExecuteAsync(@"
                INSERT INTO [User](Email, PasswordHash, Roles, StudentId)
                VALUES(@Email, @PasswordHash, @Roles, @StudentId)",
                user
            );
        }
    }
}
