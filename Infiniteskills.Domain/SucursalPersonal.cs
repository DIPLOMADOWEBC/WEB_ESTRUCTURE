using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("sucursal_personal")]
    public partial class SucursalPersonal: AuditableEntity
    {
        [Key]
        [Column("sucursal_personal_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SucursalPersonalId { get; set; }


        [Column("sucursal_id")]
        public int SucursalId { get; set; }


        [Column("personal_id")]
        public int PersonalId { get; set; }
        public virtual Personal Personal { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
}
