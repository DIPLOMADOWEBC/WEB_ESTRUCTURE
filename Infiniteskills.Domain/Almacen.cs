using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("almacen")]
    public partial class Almacen: AuditableEntity
    {
        public Almacen()
        {
            Serie = new HashSet<Serie>();
            Orden = new HashSet<Orden>();
            OrdenSaldo = new HashSet<OrdenSaldo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("almacen_id")]
        public int AlmacenId { get; set; }


        [Column("sucursal_id")]
        public int SucursalId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }


        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("stock_sn")]
        [StringLength(1)]
        public string StockSn { get; set; }

        public virtual Sucursal Sucursal { get; set; }

        public virtual ICollection<Serie> Serie { get; set; }
        public virtual ICollection<OrdenSaldo> OrdenSaldo { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
    }
}
