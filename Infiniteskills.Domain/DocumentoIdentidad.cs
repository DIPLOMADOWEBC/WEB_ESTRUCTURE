using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("doc_identidad")]
    public partial class DocumentoIdentidad:AuditableEntity
    {
        public DocumentoIdentidad()
        {
            Proveedor = new HashSet<Proveedor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("doc_identidad_id")]
        public int DocumentoIdentidadId { get; set; }

        [Required]
        [Column("doc_identidad")]
        public string Codigo { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

      

        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
