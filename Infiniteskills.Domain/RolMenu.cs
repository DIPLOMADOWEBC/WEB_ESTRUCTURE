using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("rol_menu")]
    public partial class RolMenu 
    {
      

        [Key]
        [Column("rol_menu_id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RolMenuId { get; set; }

        [Required]
        [Column("rol_id")]
        public int RolId { get; set; }

        [Required]
        [Column("menu_id")]
        public int MenuId { get; set; }

        [StringLength(1)]
        [Column("estado_check")]
        public string EstadoCheck { get; set; }

        [StringLength(1)]
        [Column("lectura")]
        public string Lectura { get; set; }

        [StringLength(1)]
        [Column("escritura")]
        public string Escritura { get; set; }

        [Column("anulado")]
        public string Anulado { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Rol Rol { get; set; }

    }
}