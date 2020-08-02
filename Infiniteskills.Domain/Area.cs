using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("area")]
    public partial class Area:AuditableEntity
    {
        public Area()
        {
            Contacto = new HashSet<Contacto>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("area_id")]
        public int AreaId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        public virtual ICollection<Contacto> Contacto { get; set; }

    }
}
