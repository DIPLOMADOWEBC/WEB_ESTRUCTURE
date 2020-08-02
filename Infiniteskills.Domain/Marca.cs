using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("marca")]
    public partial class Marca: AuditableEntity
    {
        public Marca()
        {
            Producto = new HashSet<BienServicio>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("marca_id")]
        public int MarcaId { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Column("marca")]
        public string Codigo { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

    

        public virtual ICollection<BienServicio> Producto { get; set; }
    }
}
