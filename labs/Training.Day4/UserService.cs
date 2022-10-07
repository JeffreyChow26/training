using Training.Day4.Data;
using Training.Day4.Models;

namespace Training.Day4
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> users)
        {
            _userRepository = users;
        }

        public User Authenticate(string email, byte[] passwordHash)
        {
            return null;
        }

        public void Register(string email, string password)
        {

        }
    }
}
