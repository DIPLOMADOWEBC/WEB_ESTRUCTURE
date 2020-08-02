using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("tabla")]
    public partial class Tabla
    {

        public Tabla()
        {
            PeriodoCorrelativo = new HashSet<PeriodoCorrelativo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tabla_id", Order = 1)]
        public int TablaId { get; set; }

        [Required]
        [Column("tabla")]
        public string Codigo { get; set; }

        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }

  
        [Required]
        [Column("formato")]
        public string Formato { get; set; }

        [Required]
        [StringLength(1)]
        [Column("estado")]
        public string Estado { get; set; }

        [Required]
        [Column("usuario_creacion_id")]
        public int UsuarioCreacionId { get; set; }

        [Required]
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("usuario_modifica_id")]
        public int? UsuarioModificacionId { get; set; }

        [Column("fecha_modifica")]
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<PeriodoCorrelativo> PeriodoCorrelativo { get; set; }

    }
}
