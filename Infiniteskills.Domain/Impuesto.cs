using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("impuesto")]
    public partial class Impuesto:AuditableEntity
    {
        public Impuesto()
        {
            Orden = new HashSet<Orden>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("impuesto_id")]
        public int ImpuestoId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }


        public virtual ICollection<Orden> Orden { get; set; }
    }
}
