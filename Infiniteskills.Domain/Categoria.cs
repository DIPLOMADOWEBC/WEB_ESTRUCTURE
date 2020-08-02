
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Infiniteskills.Domain
{
    [Table("categoria")]
    public partial class Categoria:AuditableEntity
    {
        public Categoria()
        {
            Producto = new HashSet<BienServicio>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        [Required]
        [Column("categoria")]
        public string Codigo { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }


        public virtual ICollection<BienServicio> Producto { get; set; }
    }
}
