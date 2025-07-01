using Microsoft.EntityFrameworkCore;

namespace MiniExpress.Data
{
    public class BdContext : DbContext
    {
        public BdContext(DbContextOptions<BdContext> options) : base(options)
        {
        }

        public DbSet<Models.PerfilModel> Perfis { get; set; }
        public DbSet<Models.UsuarioModel> Usuarios { get; set; }

        
    }
}