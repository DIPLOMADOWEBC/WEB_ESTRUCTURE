using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("mes_contable")]
    public partial class MesContable : AuditableEntity
    {
        public MesContable()
        {

            OrdenSaldo = new HashSet<OrdenSaldo>();
            Orden = new HashSet<Orden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("mes_contable_id")]
        public int MesContableId { get; set; }

        [Column("mes_contable")]
        public string Codigo { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }


        [Column("num_cierre_alm")]
        public string NombreMovimiento { get; set; }

        public virtual ICollection<Orden> Orden { get; set; }
        public virtual ICollection<OrdenSaldo> OrdenSaldo { get; set; }
    }
}
