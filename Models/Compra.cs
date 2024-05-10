using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MOSAIK.Models
{
    [Table("Compra")]
    public class Compra
    {
        [Column("CompraId")]
        [Display(Name = "Código da Compra")]
        public int CompraId { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Column("TotalCompra")]
        [Display(Name = "Total")]
        public double TotalCompra { get; set; }

        [Column("DataCompra")]
        [Display(Name = "Data da Compra")]
        public DateTime DataCompra { get; set; }

    }
}
