using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("rol_usuario")]
    public class RolUsuario
    {
        public RolUsuario()
        {
        }
  

        [Key]
        [Column("rol_usuario_id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RolUsuarioId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Required]
        [Column("rol_id")]
        public int RolId { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}