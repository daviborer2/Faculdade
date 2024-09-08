using System.ComponentModel.DataAnnotations;

namespace Faculdade.Models
{
    public class Curso
    {
        [Key] public int CursoId { get; set; }
        [Required] public string Nome { get; set; }

        public ICollection<Estudante> Estudantes { get; set; }
        public Curso()
        {
            Estudantes = [];
        }

    }
}
