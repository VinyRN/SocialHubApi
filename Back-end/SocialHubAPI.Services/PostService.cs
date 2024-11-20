using SocialHub.Domain.DTOs.Request;
using SocialHub.Domain.Entities;
using SocialHub.Domain.Interfaces.Dapper;
using SocialHub.Domain.Interfaces.Services;

namespace SocialHubAPI.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<Post> GetPostByIdAsync(Guid id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task AddPostAsync(PostRequestDTO post)
        {
            await _postRepository.AddAsync(post);
        }
    }
}
