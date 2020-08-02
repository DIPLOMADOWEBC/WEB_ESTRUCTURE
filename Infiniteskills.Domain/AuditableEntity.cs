using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    public abstract class AuditableEntity
    {

        [ScaffoldColumn(false)]
        [Required]
        [StringLength(1)]
        [Column("estado")]
        public string Estado { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        [Column("usuario_creacion_id")]
        public int UsuarioCreacionId { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [ScaffoldColumn(false)]
        [Column("usuario_modifica_id")]
        public int? UsuarioModificacionId { get; set; }

        [ScaffoldColumn(false)]
        [Column("fecha_modifica")]
        public DateTime? FechaModificacion { get; set; }
    }
}
