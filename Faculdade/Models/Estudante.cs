using System.ComponentModel.DataAnnotations;

namespace Faculdade.Models
{
    public class Estudante
    {
        [Key] public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set;}
    }
}
