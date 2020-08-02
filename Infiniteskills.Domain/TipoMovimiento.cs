using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("tipo_movimiento")]
    public class TipoMovimiento : AuditableEntity
    {
        public TipoMovimiento()
        {
            //TipoOperacion = new HashSet<TipoOperacion>();
        }

        [Key]
        [Column("tipo_movimiento_id")]
        public int TipoMovimientoId { get; set; }

        [Column("tipo_movimiento")]
        public string Codigo { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }


       // public virtual ICollection<TipoOperacion> TipoOperacion { get; set; }
    }
}
