using Microsoft.EntityFrameworkCore;
using SocialHub.Domain.Entities;
using SocialHub.Domain.Respositories.Interfaces;

namespace SocialHub.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DbContext _context;

        public PostRepository(DbContext context)
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

        public async Task AddAsync(Post post)
        {
            await _context.Set<Post>().AddAsync(post);
            await _context.SaveChangesAsync();
        }
    }
}
