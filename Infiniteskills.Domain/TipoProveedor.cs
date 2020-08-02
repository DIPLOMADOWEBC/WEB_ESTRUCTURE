using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("tipo_proveedor")]
    public partial class TipoProveedor:AuditableEntity
    {
        public TipoProveedor()
        {
            Proveedor = new HashSet<Proveedor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tipo_proveedor_id")]
        public int TipoProveedorId { get; set; }

        [Column("tipo_proveedor")]
        public string Codigo { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

     

        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
