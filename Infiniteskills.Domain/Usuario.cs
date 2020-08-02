using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("usuario")]
    public partial class Usuario:AuditableEntity
    {
        public Usuario()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Required]
        [Column("personal_id")]
        public int PersonalId { get; set; }

        [Required]
        [Column("usuario")]
        public string UserName { get; set; }

        [Required]
        [Column("nombres")]
        public string Nombre { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [Column("password_hash")]
        public byte[] PasswordHash { get; set; }

  
        public virtual Personal Personal { get; set; }
    }
}
