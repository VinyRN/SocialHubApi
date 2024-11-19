using Microsoft.AspNetCore.Mvc;
using SocialHub.Domain.DTOs;
using SocialHubAPI.UseCases;

namespace SocialHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly LoginUserUseCase _loginUserUseCase;
        private readonly TokenService _tokenService;

        public AuthController(RegisterUserUseCase registerUserUseCase, LoginUserUseCase loginUserUseCase, TokenService tokenService)
        {
            _registerUserUseCase = registerUserUseCase;
            _loginUserUseCase = loginUserUseCase;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                await _registerUserUseCase.RegisterAsync(request.Email, request.Password);
                return Ok("Usuário registrado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _loginUserUseCase.AuthenticateAsync(request.Username, request.Password);
                if (user == null)
                {
                    return Unauthorized("Credenciais inválidas.");
                }

                // Gerar token JWT
                var token = _tokenService.GenerateToken(user);

                // Retornar o token e os dados do usuário
                return Ok(new
                {
                    token,
                    user = new
                    {
                        id = user.Id,
                        email = user.Username,
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao realizar login: {ex.Message}");
            }
        }
    }
}
