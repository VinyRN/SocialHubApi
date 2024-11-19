using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialHub.Domain.Entities;
using SocialHub.Domain.Respositories.Interfaces;

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
        try
        {
            var posts = await _postRepository.GetAllAsync();
            return Ok(posts);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao recuperar posts: {ex.Message}");
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreatePost([FromBody] Post post)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            post.UserId = Guid.Parse(User.FindFirst("sub")?.Value); // Associa o post ao usuário autenticado
            await _postRepository.AddAsync(post);
            return Ok(post);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao criar o post: {ex.Message}");
        }
    }
}
