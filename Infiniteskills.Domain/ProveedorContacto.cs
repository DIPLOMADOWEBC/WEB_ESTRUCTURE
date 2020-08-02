using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("prov_contacto")]
    public partial class ProveedorContacto: AuditableEntity
    {
        public ProveedorContacto()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("prov_contacto_id")]
        public int ProveedorContactoId { get; set; }

        [Required]
        [Column("contacto_id")]
        public int ContactoId { get; set; }

        [Required]
        [Column("proveedor_id")]
        public int ProveedorId { get; set; }
  
        public virtual Contacto Contacto { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
