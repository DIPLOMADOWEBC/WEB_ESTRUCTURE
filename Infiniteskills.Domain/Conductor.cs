using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("conductor")]
    public class Conductor : AuditableEntity
    {
        public Conductor()
        {
            Orden = new HashSet<Orden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("conductor_id")]
        public int ConductorId { get; set; }


        [Column("documento")]
        public string NumeroDocumento { get; set; }

        [Column("nombres")]
        public string Nombre { get; set; }

        [Column("num_licencia")]
        public string NumeroLicencia { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        public virtual ICollection<Orden> Orden { get; set; }
    }
}
