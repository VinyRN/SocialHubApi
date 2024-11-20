using Microsoft.EntityFrameworkCore;
using SocialHub.Domain.DTOs.Request;
using SocialHub.Domain.Entities;
using SocialHub.Domain.Interfaces.Dapper;
using SocialHub.Infrastructure.Data;

namespace SocialHub.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Set<Post>().OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<Post> GetByIdAsync(Guid id)
        {
            return await _context.Set<Post>().FindAsync(id);
        }

        public async Task AddAsync(PostRequestDTO post)
        {
            await _context.Set<PostRequestDTO>().AddAsync(post);
            await _context.SaveChangesAsync();
        }
    }
}
