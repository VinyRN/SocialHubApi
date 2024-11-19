using SocialHub.Domain.Entities;
using SocialHub.Domain.Respositories.Interfaces;

namespace SocialHubAPI.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterAsync(string username, string password)
        {
            // Verificar se o usuário já existe
            var userExists = await _userRepository.FindByUsernameAsync(username);
            if (userExists != null)
            {
                throw new Exception("Usuário já existe.");
            }

            // Gerar o hash da senha
            var passwordHash = HashPassword(password);

            var newUser = new User(username, passwordHash);

            await _userRepository.AddAsync(newUser);
        }


        private string HashPassword(string password)
        {
            // Simulação de hash. Use algo como BCrypt, Argon2 em produção.
            return password;
        }
    }
}
