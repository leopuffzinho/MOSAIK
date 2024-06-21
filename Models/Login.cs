using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSAIK.Models
{
    [Table("Login")]
    public class Login
    {
        [Column("LoginId")]
        [Display(Name = "Código do Login")]

        public int LoginId { get; set; }

        [Column("NomeUsuario")]
        [Display(Name = "Usuário")]

        public string NomeUsuario { get; set; } = string.Empty;

        [Column("SenhaUsuario")]
        [Display(Name = "Senha")]

        public string SenhaUsuario { get; set; } = string.Empty;
    }
}
