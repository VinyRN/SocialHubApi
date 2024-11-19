using System;
using System.ComponentModel.DataAnnotations;

namespace SocialHub.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O título não pode exceder 100 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O conteúdo é obrigatório.")]
        [MaxLength(1000, ErrorMessage = "O conteúdo não pode exceder 1000 caracteres.")]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
