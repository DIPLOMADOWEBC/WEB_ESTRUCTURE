using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("tipo_doc_com")]
    public partial class DocumentoComercial:AuditableEntity
    {
        public DocumentoComercial()
        {
            Pedido = new HashSet<Orden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tipo_doc_com_id")]
        public int DocumentoComercialId { get; set; }

        [Required]
        [Column("tipo_doc_com")]
        public string Codigo { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        public virtual ICollection<Orden> Pedido { get; set; }

    }
}
