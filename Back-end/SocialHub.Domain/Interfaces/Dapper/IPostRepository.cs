using SocialHub.Domain.DTOs.Request;
using SocialHub.Domain.Entities;

namespace SocialHub.Domain.Interfaces.Dapper
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(Guid id);
        Task AddAsync(PostRequestDTO post);
    }
}
