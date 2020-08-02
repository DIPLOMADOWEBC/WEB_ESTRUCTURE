using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("linea")]
    public class Linea: AuditableEntity
    {
        public Linea()
        {
            BienServicio = new HashSet<BienServicio>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("linea_id")]
        public int LineaId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }


       public virtual ICollection<BienServicio> BienServicio { get; set; }
    }
}
