using Faculdade.Models;
using Microsoft.EntityFrameworkCore;

namespace Faculdade.Data
{
    public class FaculdadeContext : DbContext
    {
        public FaculdadeContext(DbContextOptions<FaculdadeContext> options) : base(options) { }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>().HasMany(c => c.Estudantes).WithOne(e => e.Curso).HasForeignKey(e => e.CursoId);
        }
    }
}
