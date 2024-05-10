using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSAIK.Models
{
    [Table("Tamanho")]
    public class Tamanho
    {
        [Column("TamanhoId")]
        [Display(Name = "Código do Tamanho")]
        public int TamanhoId { get; set; }

        [Column("NomeTamanho")]
        [Display(Name = "Tamanho")]
        public string NomeTamanho { get; set; } = string.Empty;
    }
}
