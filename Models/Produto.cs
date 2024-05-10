using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSAIK.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("ProdutoId")]
        [Display(Name = "Código do Produto")]

        public int ProdutoId { get; set; }

        [Column("NomeProduto")]
        [Display(Name = "Produto")]

        public string NomeProduto { get; set; } = string.Empty;

        [Column("DescricaoProduto")]
        [Display(Name = "Descrição")]

        public string DescricaoProduto { get; set; } = string.Empty;

        [ForeignKey("TipoProdutoId")]
        public int TipoProdutoId { get; set; }
        [Display(Name = "Tipo do Produto")]
        public TipoProduto? TipoProduto { get; set; }

        [Column("PrecoProduto")]
        [Display(Name = "Preço")]

        public double PrecoProduto { get; set; }

        [Column("QtdEstoque")]
        [Display(Name = "Estoque")]

        public int QtdEstoque { get; set; }

        [ForeignKey("MarcaId")]
        public int MarcaId { get; set; }
        public Marca? Marca { get; set; }

        [ForeignKey("SecaoId")]
        public int SecaoId { get; set; }
        [Display(Name = "Seção")]
        public Secao? Secao { get; set; }

        [ForeignKey("TamanhoId")]
        public int TamanhoId { get; set; }
        public Tamanho? Tamanho { get; set; }

    }
}
