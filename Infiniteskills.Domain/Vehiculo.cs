using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("vehiculo")]
    public class Vehiculo : AuditableEntity
    {
        public Vehiculo()
        {
            Orden = new HashSet<Orden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("vehiculo_id")]
        public int VehiculoId { get; set; }

        [Column("num_placa")]
        public string NumeroPlaca { get; set; }

        [Column("placa")]
        public string Placa { get; set; }

        [Column("constancia")]
        public string Constancia { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
    }
}
