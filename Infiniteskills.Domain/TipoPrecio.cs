using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("tipo_precio")]
    public class TipoPrecio:AuditableEntity
    {
        public TipoPrecio()
        {
            Proveedor = new HashSet<Proveedor>();
            Orden = new HashSet<Orden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tipo_precio_id")]
        public int TipoPrecioId { get; set; }


        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        public virtual ICollection<Proveedor> Proveedor { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
    }
}
