using Microsoft.EntityFrameworkCore;
using SocialHub.Domain.Entities;
using SocialHub.Domain.Interfaces.Dapper;
using SocialHub.Infrastructure.Data;


namespace SocialHub.data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
