using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faculdade.Models
{
    public class Estudante
    {
        [Key] public int Matricula { get; set; }
        [Required] public string Nome { get; set; }

        public Curso? Curso { get; set; }
        [ForeignKey("Curso")] public int CursoId { get; set; }

    }
}
