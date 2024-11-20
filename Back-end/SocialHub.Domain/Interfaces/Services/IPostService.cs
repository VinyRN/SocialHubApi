using SocialHub.Domain.DTOs.Request;
using SocialHub.Domain.Entities;

namespace SocialHub.Domain.Interfaces.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(Guid id);
        Task AddPostAsync(PostRequestDTO post);
    }
}
