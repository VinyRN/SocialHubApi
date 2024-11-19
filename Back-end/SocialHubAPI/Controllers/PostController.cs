using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialHub.Domain.Entities;
using SocialHub.Domain.Respositories.Interfaces;

namespace SocialHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetAllAsync();
            return Ok(posts);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos.");
            }

            post.UserId = Guid.Parse(User.FindFirst("sub")?.Value); // Associa o post ao usuário autenticado
            await _postRepository.AddAsync(post);
            return Ok(post);
        }
    }
}
