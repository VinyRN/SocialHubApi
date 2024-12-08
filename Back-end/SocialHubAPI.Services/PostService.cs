using SocialHub.Domain.DTOs.Request;
using SocialHub.Domain.Entities;
using SocialHub.Domain.Interfaces.Dapper;
using SocialHub.Domain.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using SocialHub.SignalR; 

namespace SocialHubAPI.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IHubContext<NotificationHub> _hubContext;

        public PostService(IPostRepository postRepository, IHubContext<NotificationHub> hubContext)
        {
            _postRepository = postRepository;
            _hubContext = hubContext;
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
            // Adiciona o post ao repositório
            await _postRepository.AddAsync(post);

            // Dispara uma notificação para todos os usuários (ou usuários específicos)
            var notificationMessage = $"Novo post adicionado: {post.Title}";
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", notificationMessage);
        }
    }
}
