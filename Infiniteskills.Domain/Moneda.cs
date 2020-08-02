using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("moneda")]
    public partial class Moneda:AuditableEntity
    {
        public Moneda()
        {
            Orden = new HashSet<Orden>();
            Producto = new HashSet<BienServicio>();
            Proveedor = new HashSet<Proveedor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("moneda_id")]
        public int MonedaId { get; set; }

        [Required]
        [Column("moneda")]
        public string Codigo { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }


        [Required(AllowEmptyStrings =true)]
        [Column("simbolo")]
        public string Simbolo { get; set; }

     
        public virtual ICollection<BienServicio> Producto { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
