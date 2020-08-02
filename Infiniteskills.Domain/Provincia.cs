using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("provincia")]
    public partial class Provincia
    {
        public Provincia()
        {
            Distrito = new HashSet<Distrito>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("provincia_id")]
        public int ProvinciaId { get; set; }

        [Required]
        [Column("provincia")]
        public string Codigo { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [Column("departamento_id")]
        public int DepartamentoId { get; set; }

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

        public virtual ICollection<Distrito> Distrito { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
