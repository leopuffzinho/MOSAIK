using Microsoft.EntityFrameworkCore;

namespace MOSAIK.Models
{
    public class Contexto : DbContext

    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }


        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Compra_Has_Produto> Compra_Has_Produto { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Secao> Secao { get; set; }
        public DbSet<Tamanho> Tamanho { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }
    }
}
