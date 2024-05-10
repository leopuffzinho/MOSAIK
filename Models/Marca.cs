using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MOSAIK.Models
{
    [Table("Marca")]
    public class Marca
    {
        [Column("MarcaId")]
        [Display(Name = "Código da Marca")]
        public int MarcaId { get; set; }

        [Column("NomeMarca")]
        [Display(Name = "Marca")]
        public string NomeMarca { get; set; } = string.Empty;
    }
}
