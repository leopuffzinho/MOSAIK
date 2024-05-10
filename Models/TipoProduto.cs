using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSAIK.Models
{
    [Table("TipoProduto")]
    public class TipoProduto
    {
        [Column("TipoProdutoId")]
        [Display(Name = "Código do Tipo do Produto")]
        public int TipoProdutoId { get; set; }

        [Column("NomeTipoProduto")]
        [Display(Name = "Tipo do Produto")]
        public string NomeTipoProduto { get; set; } = string.Empty;
    }
}
