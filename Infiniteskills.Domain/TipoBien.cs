using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("tipo_bien")]
    public class TipoBien:AuditableEntity
    {
        public TipoBien()
        {
            Producto = new HashSet<BienServicio>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tipo_bien_id")]
        public int TipoBienId { get; set; }


        [Column("nombre")]
        public string Nombre { get; set; }

        public virtual ICollection<BienServicio> Producto { get; set; }
    }
}
