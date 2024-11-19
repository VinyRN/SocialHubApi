using SocialHub.Domain.Entities;
using SocialHub.Domain.Respositories.Interfaces;

namespace SocialHubAPI.UseCases
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public LoginUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || !user.VerifyPassword(password))
                throw new UnauthorizedAccessException("Credenciais inválidas.");

            return user; 
        }
    }
}
