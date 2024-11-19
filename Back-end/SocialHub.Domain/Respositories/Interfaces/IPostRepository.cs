using SocialHub.Domain.Entities;

namespace SocialHub.Domain.Respositories.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(Guid id);
        Task AddAsync(Post post);
    }
}
