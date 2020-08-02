using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("contacto")]
    public partial class Contacto : AuditableEntity
    {
        public Contacto()
        {
            ProveedorContacto = new HashSet<ProveedorContacto>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("contacto_id")]
        public int ContactoId { get; set; }


        [Column("area_id")]
        public int AreaId { get; set; }

        [Required]
        [Column("num_ruc")]
        public string NumeroDocumentoContacto { get; set; }

        [Column("nombres")]
        public string NombreContacto { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Column("telefono")]
        public string TelefonoContacto { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Column("celular")]
        public string CelularContacto { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Column("email")]
        public string EmailContacto { get; set; }


        [Required(AllowEmptyStrings = true)]
        [Column("direccion")]
        public string DireccionContacto { get; set; }

        public virtual Area Area { get; set; }

        public virtual ICollection<ProveedorContacto> ProveedorContacto { get; set; }
    }
}
