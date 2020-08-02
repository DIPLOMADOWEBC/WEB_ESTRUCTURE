
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Infiniteskills.Domain
{
   [Table("rol")]
   public partial class Rol
   {
      public Rol()
      {
         RolMenu = new HashSet<RolMenu>();
         RolUsuario = new HashSet<RolUsuario>();
      }


      [Key]
      [Column("rol_id", Order = 0)]
      [DatabaseGenerated(DatabaseGeneratedOption.None)]
      public int RolId { get; set; }

      [Required(AllowEmptyStrings=true)]
      [StringLength(10)]
      [Column("rol")]
      public string Codigo { get; set; }

      [Required]
      [StringLength(100)]
      [Column("nombre")]
      public string Nombre { get; set; }

      [Column("origen_registro_id")]
      public int OrigenRegistroId { get; set; }

      [Required]
      [StringLength(1)]
      [Column("estado")]
      public string Estado { get; set; }
      public virtual ICollection<RolMenu> RolMenu { get; set; }
      public virtual ICollection<RolUsuario> RolUsuario { get; set; }

   }
}