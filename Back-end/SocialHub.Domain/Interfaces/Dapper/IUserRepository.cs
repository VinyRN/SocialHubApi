using SocialHub.Domain.Entities;

namespace SocialHub.Domain.Interfaces.Dapper
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByUsernameAsync(string username);

        Task<User> FindByUsernameAsync(string username);
    }
}
