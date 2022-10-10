using TheUniversity.Models;

namespace TheUniversity.Repositories
{
    public interface IUserRepository
    {
        Task<User?> Find(string email);
        Task Create(User user);
    }
}
