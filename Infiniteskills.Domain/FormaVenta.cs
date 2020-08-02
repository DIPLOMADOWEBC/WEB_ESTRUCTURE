using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("forma_venta")]
    public class FormaVenta:AuditableEntity
    {
        public FormaVenta()
        {
            Proveedor = new HashSet<Proveedor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("forma_venta_id")]
        public int FormaVentaId { get; set; }

        [Required]
        [Column("forma_venta")]
        public string Codigo { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

  

        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
