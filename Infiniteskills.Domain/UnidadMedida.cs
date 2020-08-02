using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("unidad_medida")]
    public partial class UnidadMedida:AuditableEntity
    {
        public UnidadMedida()
        {
            Producto = new HashSet<BienServicio>();
 
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("unidad_medida_id")]
        public int UnidadMedidaId { get; set; }

        [Column("unidad_medida")]
        public string Codigo { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("abreviatura")]
        public string Abreaviatura { get; set; }

  
        public virtual ICollection<BienServicio> Producto { get; set; }


        
    }
}
