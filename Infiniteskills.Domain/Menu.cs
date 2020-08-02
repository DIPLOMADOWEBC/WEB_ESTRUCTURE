using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("menu")]
    public partial class Menu 
    {
        public Menu()
        {
            RolMenu = new HashSet<RolMenu>();
        }
  

        [Key]
        [Column("menu_id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [Column("area")]
        public string Area { get; set; }

        [StringLength(50)]
        [Column("url")]
        public string Url { get; set; }

        [Required]
        [StringLength(50)]
        [Column("imagen")]
        public string RutaImagen { get; set; }

        [Column("menu_padre_id")]
        public int? MenuPadreId { get; set; }

        [Column("orden")]
        public int Orden { get; set; }

        [Required]
        [StringLength(1)]
        [Column("estado")]
        public string Estado { get; set; }

        public virtual ICollection<RolMenu> RolMenu { get; set; }

    }
}
