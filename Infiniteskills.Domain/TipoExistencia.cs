using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infiniteskills.Domain
{
    [Table("tipo_existencia")]
    public partial class TipoExistencia
    {
        public TipoExistencia()
        {
            BienServicio = new HashSet<BienServicio>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tipo_existencia_id")]
        public int TipoExistenciaId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(1)]
        [Column("estado")]
        public string Estado { get; set; }

        [Required]
        [Column("usuario_creacion_id")]
        public int UsuarioCreacionId { get; set; }

        [Required]
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("usuario_modifica_id")]
        public int? UsuarioModificacionId { get; set; }

        [Column("fecha_modifica")]
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<BienServicio> BienServicio { get; set; }
    }
}
