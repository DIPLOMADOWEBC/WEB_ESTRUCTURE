using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("distrito")]
    public partial class Distrito : AuditableEntity
    {
        public Distrito()
        {
            Proveedor = new HashSet<Proveedor>();
            Direccion = new HashSet<DireccionProveedor>();
            Sucursal = new HashSet<Sucursal>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("distrito_id")]
        public int DistritoId { get; set; }

        [Required]
        [Column("distrito")]
        public string Codigo { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [Column("provincia_id")]
        public int ProvinciaId { get; set; }

        public virtual ICollection<Proveedor> Proveedor { get; set; }
        public virtual ICollection<DireccionProveedor> Direccion { get; set; }
        public virtual ICollection<Sucursal> Sucursal { get; set; }
        public virtual Provincia Provincia { get; set; }
    }
}
