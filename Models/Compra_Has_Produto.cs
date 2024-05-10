using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSAIK.Models
{
    [Table("Compra_Has_Produto")]
    public class Compra_Has_Produto
    {
        [Column("Compra_Has_ProdutoId")]
        [Display(Name = "Código da Compra")]

        public int Compra_Has_ProdutoId { get; set; }

        [ForeignKey("CompraId")]
        public int CompraId { get; set; }

        public Compra? Compra { get; set; }

        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }

        public Produto? Produto { get; set; }
    }
}
