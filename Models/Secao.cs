using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSAIK.Models
{
    [Table("Secao")]
    public class Secao
    {
        [Column("SecaoId")]
        [Display(Name = "Código da Seção")]
        public int SecaoId { get; set; }

        [Column("NomeSecao")]
        [Display(Name = "Seção")]
        public string NomeSecao { get; set; } = string.Empty;
    }
}
