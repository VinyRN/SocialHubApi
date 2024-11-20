namespace SocialHub.Domain.DTOs.Request
{
    public class PostRequestDTO
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }
    }
}
