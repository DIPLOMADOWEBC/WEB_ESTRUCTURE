using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("tipo_operacion")]
    public  partial class TipoOperacion
    {
        public TipoOperacion()
        {
            Orden = new HashSet<Orden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tipo_operacion_id")]
        public int TipoOperacionId { get; set; }

        [Required]
        [Column("tipo_operacion")]
        public string Codigo { get; set; }

        //[Column("tipo_movimiento_id")]
        //public int TipoMovimientoId { get; set; }

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

      //  public virtual TipoMovimiento TipoMovimiento { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
    }
}
