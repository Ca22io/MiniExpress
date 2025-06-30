using System.ComponentModel.DataAnnotations;

namespace WebApplication.Model
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required, MaxLength(2000)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data de criação com valor padrão
    }
}