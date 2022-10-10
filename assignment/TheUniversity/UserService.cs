using System.Security.Cryptography;
using System.Text;
using TheUniversity.Models;
using TheUniversity.Repositories;

namespace TheUniversity 
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository users)
        {
            _userRepository = users;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            User? user = await _userRepository.Find(email);

            if (user == null)
            {
                throw new Exception("User does not exist.");
            }

            byte[] passwordHash = ComputeHash(password);

            if (!user.PasswordHash.AsSpan().SequenceEqual(passwordHash))
            {
                throw new Exception("Password invalid.");
            }

            return user;
        }

        public async Task<User> Register(string email, string password)
        {
            byte[] passwordHash = ComputeHash(password);

            User user = new()
            {
                Id = 0,
                Email = email,
                PasswordHash = passwordHash,
                Roles = Role.User,
                StudentId = null
            };

            await _userRepository.Create(user);

            return user;
        }

        private static byte[] ComputeHash(string password)
        {
            // TODO: Reduce allocations.

            using SHA256 hasher = SHA256.Create();

            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = hasher.ComputeHash(bytes);

            return hash;
        }
    }
}
