using Microsoft.EntityFrameworkCore;
using WebApplication.Model;

public class BlogDbContext : DbContext
{
    // O construtor que recebe as opções de configuração do banco de dados
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
    }

    // Este é o nosso "catálogo" ou "tabela" de Posts.
    // O nome da propriedade, "Posts", será o nome padrão da tabela no banco de dados.
    public DbSet<Post> Posts { get; set; }
}