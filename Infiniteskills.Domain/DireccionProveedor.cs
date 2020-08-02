using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("direccion")]
    public class DireccionProveedor: AuditableEntity
    {
        public DireccionProveedor()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("direccion_id")]
        public int DireccionId { get; set; }

        [Column("proveedor_id")]
        public int ProveedorId { get; set; }

        [Required]
        [Column("nombre_via")]
        public string NombreDireccion { get; set; }


        [Required(AllowEmptyStrings =true)]
        [Column("referencia")]
        public string Referencia { get; set; }


        [Column("fiscal")]
        public string Fiscal { get; set; }

        [Column("distrito_id")]
        public int DistritoId { get; set; }


       // public virtual Proveedor Proveedor { get; set; }
        public virtual Distrito Distrito { get; set; }

    }
}
