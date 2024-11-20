using System;

namespace SocialHub.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relacionamento com o usuário (opcional)
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
