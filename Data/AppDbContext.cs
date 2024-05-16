using Microsoft.EntityFrameworkCore;
using QuadrinhosAPI.Models;

namespace QuadrinhosAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<EditoraModel> Editora { get; set; }
        public DbSet<TituloModel> Titulo { get; set; }
    }
}
