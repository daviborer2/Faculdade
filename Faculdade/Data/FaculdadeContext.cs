using Faculdade.Models;
using Microsoft.EntityFrameworkCore;

namespace Faculdade.Data
{
    public class FaculdadeContext : DbContext
    {
        public FaculdadeContext(DbContextOptions<FaculdadeContext> options) : base(options) { }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }
    }
}
