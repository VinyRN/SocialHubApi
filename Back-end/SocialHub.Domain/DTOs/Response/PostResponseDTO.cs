namespace SocialHub.Domain.DTOs.Response
{
    public class PostResponseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; }
    }
}
